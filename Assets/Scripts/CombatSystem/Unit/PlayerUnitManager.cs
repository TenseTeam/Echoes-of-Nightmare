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

    [RequireComponent(typeof(UnitHand))]
    public class PlayerUnitManager : UnitManager
    {
        public UnitHand UnitHand { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            UnitHand = GetComponent<UnitHand>();
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