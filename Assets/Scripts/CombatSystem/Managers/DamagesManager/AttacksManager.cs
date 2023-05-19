namespace ProjectEON.CombatSystem.Managers
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;

    public class AttacksManager : MonoBehaviour
    {
        [SerializeField, Header("Statistics")]
        private int _criticalMultiplier = 2;

        [field: SerializeField, Header("Status Effects Statistics"), Range(0, 100)]
        public sbyte ReceiveDamageReduction {  get; private set; }

        [field: SerializeField, Min(0)]
        public int BleedDamage { get; private set; }



        public void UseSkillOnUnit(UnitManager unitAttacker, SkillData skillAttack, UnitManager unitReceiver)
        {
            int randomPower = CalculateDamage(skillAttack, unitReceiver, out bool hasSucceeded);

            Action<UnitManager> _onSkillAttack = null;

            switch (skillAttack.SkillType)
            {
                case SkillType.Heal:
                    _onSkillAttack += (receiver) =>
                    {
                        receiver.Unit.HealHitPoints(randomPower);
                    };
                    break;
                case SkillType.Damage:
                    _onSkillAttack += (receiver) =>
                    {
                        receiver.Unit.TakeDamage(randomPower);
                    };
                    break;
            }

            if (hasSucceeded) // I put this here using a bool because i need to check if the critical has succeeded only after the TakeDamage due to delagetes order for the UnitUI
                unitReceiver.ReceiveCritical();

            unitAttacker.UnitAnimatorController.AnimSkill(skillAttack);

            if (skillAttack.IsGroupAttack)
            {
                AffectGroupWithSkill(skillAttack, unitAttacker, unitReceiver, _onSkillAttack);
                return;
            }

            SendAttackToUnit(skillAttack, unitReceiver, _onSkillAttack);
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
            //power -= power / 100 * unitReceiver.UnitStatusEffects.CurrentDamageReduction;

            return power;
        }

        private void SendAttackToUnit(SkillData skill, UnitManager unitReceiver, Action<UnitManager> onSkillAttack)
        {
            onSkillAttack.Invoke(unitReceiver);
            ApplyEffectsStatus(skill.SkillStatusEffects, unitReceiver);
            unitReceiver.UnitAnimatorController.AnimGetHit();
        }

        private void AffectGroupWithSkill(SkillData skill, UnitManager unitAttacker, UnitManager unitReceiver, Action<UnitManager> onSkillAttack)
        {
            List<UnitManager> units = unitReceiver.Party.GetComposedUnits();

            for (int i = 0; i < units.Count; i++)
            {
                if (units[i] != unitReceiver) // I have to do this because I cannot dispose the unit that i use to refer the party
                    SendAttackToUnit(skill, units[i], onSkillAttack);
            }

            SendAttackToUnit(skill, unitReceiver, onSkillAttack); // So i do the damage after
        }
    }
}