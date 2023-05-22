namespace ProjectEON.CombatSystem.StatusEffects.Factory
{
    using System;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;
    using Extension.Patterns.Factory.Interfaces;

    public static class StatusEffectFactory
    {
        public static StatusEffectBase Construct(StatusEffectData statusData, UnitManager unitManager, AttacksManager attacksManager)
        {
            if (statusData is BleedStatusData)
                return new BleedStatus(statusData, unitManager, attacksManager);

            if (statusData is DamageDownStatusData)
                return new DamageDownStatus(statusData, unitManager, attacksManager);

            if (statusData is DamageReductionStatusData)
                return new DamageReductionStatus(statusData, unitManager, attacksManager);

            if (statusData is FearStatusData)
                return new FearStatus(statusData, unitManager, attacksManager);

            if (statusData is StunStatusData)
                return new StunStatus(statusData, unitManager, attacksManager);

            throw new NullReferenceException($"Type of {nameof(statusData)} could not be instantiated because was not found.");
        }
    }
}