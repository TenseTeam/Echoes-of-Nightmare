namespace ProjectEON.CombatSystem.Units
{
    using UnityEngine;
    using Extension.Patterns.ObjectPool;
    using ProjectEON.SOData;
    using ProjectEON.PartySystem;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Units.CardsSystem;
    using System.Collections.Generic;

    [RequireComponent(typeof(UnitHand))]
    [RequireComponent(typeof(UnitDeck))]
    public class PlayerUnitManager : UnitManager
    {
        public UnitHand UnitHand { get; private set; }
        public UnitDeck UnitDeck { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            TryGetComponent(out UnitHand hand);
            TryGetComponent(out UnitDeck deck);
            UnitHand = hand;
            UnitDeck = deck;
        }

        public void Init(UnitData data, Party relatedParty, Pool associatedPool, CardsPool cardsPool, RectTransform handRectTransform)
        {
            base.Init(data, relatedParty, associatedPool);
            UnitDeck.Init(data.Skills);
            UnitHand.Init($"{UnitData.UnitName} Hand", handRectTransform, this, UnitDeck, cardsPool);
        }
    }
}