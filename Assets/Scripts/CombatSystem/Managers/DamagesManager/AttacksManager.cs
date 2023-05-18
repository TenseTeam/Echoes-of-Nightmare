namespace ProjectEON.CombatSystem.Managers
{
    using System;
    using UnityEngine;
    using UnityEditor.Experimental.GraphView;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using SOData.Structures.Enums;

    public class AttacksManager : MonoBehaviour
    {
        [SerializeField, Header("Statistics")]
        private int _criticalMultiplier = 2;

        [field: SerializeField, Header("Status Effects Statistics"), Range(0, 100)]
        public sbyte ReceiveDamageReduction {  get; private set; }
        [field: SerializeField, Min(0)]
        public uint BleedDamage { get; private set; }

        //public void ApplyEffectStatus()
        //{

        //}

        public void UseSkillOnUnit(UnitManager unitAttacker, SkillData skillAttack, UnitManager unitReceiver)
        {
            int randomPower = skillAttack.Power.Random() * RollCriticalChance(skillAttack, unitReceiver, out bool hasSucceeded);

            switch (skillAttack.SkillType)
            {
                case SkillType.Heal:
                    unitReceiver.Unit.HealHitPoints(randomPower);
                    break;
                case SkillType.Damage:
                    unitReceiver.Unit.TakeDamage(randomPower);
                    break;
            }

            if(hasSucceeded) // I put this here using a bool because i need to check if the critical has succeeded only after the TakeDamage due to delagetes order for the UnitUI
                unitReceiver.ReceiveCritical();

            unitAttacker.UnitAnimatorController.AnimSkill(skillAttack);
            unitReceiver.UnitAnimatorController.AnimGetHit();
        }

        /// <summary>
        /// Rolls the critical chance of the SkillData.
        /// </summary>
        /// <param name="skill">SkillData.</param>
        /// <returns>One on failure, Critical Multiplier of Skill Data on success.</returns>
        private int RollCriticalChance(SkillData skill, UnitManager unitReceiver, out bool hasSucceeded)
        {
            if(skill.CriticalChance >= UnityEngine.Random.Range(0, 101))
            {
                hasSucceeded = true;
                return _criticalMultiplier;
            }

            hasSucceeded = false;
            return 1;
        }
    }
}