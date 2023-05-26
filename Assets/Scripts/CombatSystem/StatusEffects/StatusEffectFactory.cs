namespace ProjectEON.CombatSystem.StatusEffects.Factory
{
    using System;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Managers;

    public static class StatusEffectFactory
    {
        /// <summary>
        /// Factory method of a <see cref="StatusEffectBase"/>.
        /// </summary>
        /// <param name="statusData"><see cref="StatusEffectData"/> of the status to construct.</param>
        /// <param name="unitManager"><see cref="UnitManager"/> target of the status.</param>
        /// <param name="attacksManager"><see cref="AttacksManager"/> of the status to construct.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static StatusEffectBase Construct(this StatusEffectData statusData, UnitManager unitManager, AttacksManager attacksManager)
        {
            if (statusData is BleedStatusData)
                return new BleedStatus(statusData, unitManager, attacksManager);

            if (statusData is DamageDownStatusData)
                return new DamageDownStatus(statusData, unitManager, attacksManager);

            if (statusData is DamageUpStatusData)
                return new DamageUpStatus(statusData, unitManager, attacksManager);

            if (statusData is DamageReductionStatusData)
                return new DamageReductionStatus(statusData, unitManager, attacksManager);

            if (statusData is FearStatusData)
                return new FearStatus(statusData, unitManager, attacksManager);

            if (statusData is StunStatusData)
                return new StunStatus(statusData, unitManager, attacksManager);

            throw new Exception($"Type of {nameof(statusData)} could not be instantiated because was not found.");
        }
    }
}