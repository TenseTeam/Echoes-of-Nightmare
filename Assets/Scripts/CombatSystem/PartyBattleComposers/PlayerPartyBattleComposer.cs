namespace ProjectEON.CombatSystem.PartyComposers
{
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using UnityEngine;

    public class PlayerPartyBattleComposer : PartyBattleComposer<PlayerUnitManager>
    {
        [SerializeField] private CardsPool _cardsPool;
        [SerializeField, Header("Container")] private RectTransform _handsContainer;

        protected override void GenerateUnit(PlayerUnitManager unit, UnitData unitData, Party relatedParty, Vector3 position)
        {
            unit.Init(unitData, relatedParty, Pool, _cardsPool, _handsContainer);
            InFightUnitsManager.Add(unit);
            SetUnitBattleName(unit);
            SetUnitBattlePosition(unit, position);
        }
    }
}