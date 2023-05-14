namespace ProjectEON.CombatSystem.PartyComposers
{
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.SOData;
    using UnityEngine;
    using UnityEngine.UI;

    public class PlayerPartyBattleComposer : PartyBattleComposer
    {
        [SerializeField] private CardsPool _cardsPool;
        [SerializeField, Header("Container")] private RectTransform _handsContainer;

        protected override void GenerateUnit(Unit unit, UnitData unitData, Vector3 position)
        {
            //base.GenerateUnit(unit, unitData, position);
            if (unit.TryGetComponent(out UnitHand unitHand))
            {
                ((PlayerUnit)unit).Init(unitData, Pool, unitHand, _cardsPool, _handsContainer);
                ComposedUnits.Add(unit);
                SetUnitBattleName(unit);
                SetUnitBattlePosition(unit, position);
            }
        }
    }
}