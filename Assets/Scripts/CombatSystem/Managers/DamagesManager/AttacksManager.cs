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
        public event Action OnCriticalSuccess;

        [SerializeField, Header("Statistics")]
        private int _criticalMultiplier;

        [field: SerializeField, Header("Status Effects Statistics")]
        public int DamageReduction {  get; private set; }
        [field: SerializeField]
        public int BleedDamage { get; private set; }

        //public void ApplyEffectStatus()
        //{

        //}

        public void UseSkillOnUnit(SkillData skillAttack, UnitManager unitReceiver, Action onAttackCompleted)
        {
            int randomPower = skillAttack.Power.Random() * RollCriticalChance(skillAttack, unitReceiver);

            switch (skillAttack.SkillType)
            {
                case SkillType.Heal:
                    unitReceiver.Unit.HealHitPoints(randomPower);
                    break;
                case SkillType.Damage:
                    unitReceiver.Unit.TakeDamage(randomPower);
                    break;
            }

            onAttackCompleted?.Invoke();
        }

        /// <summary>
        /// Rolls the critical chance of the SkillData.
        /// </summary>
        /// <param name="skill">SkillData.</param>
        /// <returns>One on failure, Critical Multiplier of Skill Data on success.</returns>
        private int RollCriticalChance(SkillData skill, UnitManager unitReceiver)
        {
            if(skill.CriticalChance >= UnityEngine.Random.Range(0, 101))
            {
                OnCriticalSuccess?.Invoke();
                unitReceiver.ReceiveCritical();
                return _criticalMultiplier;
            }
            return 1;
        }
    }
}