namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;

    public class FearStatus : StatusEffectBase
    {
        public FearStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
            UnitManagerTarget.UnitStatusEffects.ApplyFear(AttacksManager.ReceiveDamageReduction);
        }

        public override void Exit()
        {
            UnitManagerTarget.UnitStatusEffects.RemoveFear();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}