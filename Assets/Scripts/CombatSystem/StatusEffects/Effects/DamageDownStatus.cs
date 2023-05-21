namespace ProjectEON.CombatSystem.StatusEffects
{
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;

    public class DamageDownStatus : StatusEffectBase
    {
        public DamageDownStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
            UnitManagerTarget.UnitStatusEffects.ApplyDamageDown(AttacksManager.DamageDown);
        }

        public override void Exit()
        {
            UnitManagerTarget.UnitStatusEffects.RemoveDamageDown();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}