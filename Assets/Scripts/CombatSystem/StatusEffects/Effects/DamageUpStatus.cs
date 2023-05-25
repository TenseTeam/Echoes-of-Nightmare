namespace ProjectEON.CombatSystem.StatusEffects
{
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;

    public class DamageUpStatus : StatusEffectBase
    {
        public DamageUpStatus(StatusEffectData data, UnitManager unitTarget, AttacksManager attacksManager) : base(data, unitTarget, attacksManager)
        {
        }

        public override void Enter()
        {
            UnitManagerTarget.UnitStatusEffects.ApplyDamageUp(AttacksManager.DamageUp);
        }

        public override void Exit()
        {
            UnitManagerTarget.UnitStatusEffects.RemoveDamageUp();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}