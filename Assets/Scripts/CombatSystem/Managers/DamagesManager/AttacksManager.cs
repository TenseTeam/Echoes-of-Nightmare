namespace ProjectEON.CombatSystem.Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.SOData;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.PartySystem;
    using System.Linq;

    public class AttacksManager : MonoBehaviour
    {
        [SerializeField, Header("Statistics")]
        private int _criticalMultiplier = 2;

        [field: SerializeField, Header("Status Effects Statistics"), Range(0, 100)]
        public sbyte ReceiveDamageReduction {  get; private set; }

        [field: SerializeField, Min(0)]
        public int BleedDamage { get; private set; }

        public void UseSkillOnUnit(UnitManager unitAttacker, SkillData skill, UnitManager unitReceiver)
        {
            int randomPower = CalculateDamage(skill, unitReceiver, out bool hasSucceeded);

            Action<UnitManager> _onSkillAffect = null;

            switch (skill.SkillType)
            {
                case SkillType.Heal:
                    _onSkillAffect += (receiver) =>
                    {
                        receiver.Unit.HealHitPoints(randomPower);
                        if (hasSucceeded) receiver.ReceiveCritical();
                    };
                    break;
                case SkillType.Damage:
                    _onSkillAffect += (receiver) =>
                    {
                        receiver.Unit.TakeDamage(randomPower);
                        if(hasSucceeded) receiver.ReceiveCritical();
                    };
                    break;
            }

            unitAttacker.UnitAnimatorController.AnimSkill(skill);

            if (skill.IsAreaOfEffect)
            {
                AffectGroupWithSkill(skill, unitReceiver.Party, _onSkillAffect);
                return;
            }

            AffectUnitWithSkill(skill, unitReceiver, _onSkillAffect);
        }

        /// <summary>
        /// Rolls the critical chance of the SkillData.
        /// </summary>
        /// <param name="skill">SkillData.</param>
        /// <returns>One on failure, Critical Multiplier of Skill Data on success.</returns>
        private int RollCriticalChance(SkillData skill, UnitManager unitReceiver, out bool hasSucceeded)
        {
            if (skill.CriticalChance >= UnityEngine.Random.Range(0, 101))
            {
                hasSucceeded = true;
                return _criticalMultiplier;
            }

            hasSucceeded = false;
            return 1;
        }

        private void ApplyEffectsStatus(List<StatusEffectData> effects, UnitManager unitReceiver)
        {
            foreach(StatusEffectData effect in effects)
            {
                unitReceiver.UnitStatusEffects.AddStatusEffect(effect.CreateStatusEffect(unitReceiver, this));
            }
        }

        private int CalculateDamage(SkillData skill, UnitManager unitReceiver, out bool hasSucceeded)
        {
            int power = skill.Power.Random() * RollCriticalChance(skill, unitReceiver, out hasSucceeded);
            return power;
        }

        private void AffectUnitWithSkill(SkillData skill, UnitManager unitReceiver, Action<UnitManager> onSkillAffect)
        {
            onSkillAffect.Invoke(unitReceiver);
            ApplyEffectsStatus(skill.SkillStatusEffects, unitReceiver);
            unitReceiver.UnitAnimatorController.AnimGetHit();
        }

        private void AffectGroupWithSkill(SkillData skill, Party partyReceiver, Action<UnitManager> onSkillAffect)
        {
            List<UnitManager> units = partyReceiver.GetComposedUnits().ToList();

            for (int i = 0; i < units.Count; i++)
            {
                AffectUnitWithSkill(skill, units[i], onSkillAffect);
            }
        }
    }
}