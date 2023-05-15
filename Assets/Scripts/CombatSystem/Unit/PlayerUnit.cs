namespace ProjectEON.CombatSystem.Units
{
    using Extension.Patterns.ObjectPool;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.SOData;
    using UnityEngine;
    using System.Collections.Generic;
    using ProjectEON.PartySystem;

    public class PlayerUnit : Unit
    {
        public UnitHand UnitHand { get; private set; }

        public void Init(UnitData data, Party relatedParty, Pool associatedPool, UnitHand hand, CardsPool cardsPool, RectTransform handRectTransform)
        {
            base.Init(data, relatedParty, associatedPool);
            UnitHand = hand;
            GenerateHand(cardsPool, handRectTransform);
        }

        public void GenerateHand(CardsPool pool, RectTransform rectHand)
        {
            UnitHand.Init($"{Data.UnitName} Hand", rectHand, this, pool);
        }
    }
}