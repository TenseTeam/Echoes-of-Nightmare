namespace ProjectEON.CombatSystem.Units
{
    using Extension.Patterns.ObjectPool;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.SOData;
    using UnityEngine;
    using System.Collections.Generic;

    public class PlayerUnit : Unit
    {
        public UnitHand UnitHand { get; private set; }

        public void Init(UnitData data, Pool associatedPool, UnitHand hand)
        {
            base.Init(data, associatedPool);
            UnitHand = hand;
            GenerateHand();
        }

        public void GenerateHand()
        {
            UnitHand.Init($"{Data.UnitName} Hand", CombatManager.Instance.UICanvas, Data.Skills);
        }
    }
}