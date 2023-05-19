namespace ProjectEON.CombatSystem.StatusEffects
{
    using UnityEngine;
    using System.Collections;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;

    public class StunStatus : StatusEffectBase
    {
        public StunStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
            UnitManagerTarget.UnitStatusEffects.ApplyStun();
        }

        public override void Exit()
        {
            UnitManagerTarget.UnitStatusEffects.RemoveStun();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}