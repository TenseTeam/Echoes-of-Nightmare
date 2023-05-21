namespace ProjectEON.CombatSystem.Units
{
    using UnityEngine;
    using Extension.Patterns.ObjectPool;
    using ProjectEON.SOData;
    using ProjectEON.PartySystem;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Units.Hand;

    [RequireComponent(typeof(UnitHand))]
    public class PlayerUnitManager : UnitManager
    {
        public UnitHand UnitHand { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out UnitHand hand);
            UnitHand = hand;
        }

        public void Init(UnitData data, Party relatedParty, Pool associatedPool, CardsPool cardsPool, RectTransform handRectTransform)
        {
            base.Init(data, relatedParty, associatedPool);
            GenerateHand(cardsPool, handRectTransform);
        }

        public void GenerateHand(CardsPool pool, RectTransform rectHand)
        {
            UnitHand.Init($"{UnitData.UnitName} Hand", rectHand, this, pool);
        }
    }
}