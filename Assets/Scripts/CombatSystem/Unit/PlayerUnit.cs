namespace ProjectEON.CombatSystem.Units
{
    using Extension.Patterns.ObjectPool;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Manager;
    using ProjectEON.SOData;
    using UnityEngine;

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
            UnitHand.Init($"{Data.unitName} Hand", CombatManager.Instance.UICanvas, Data.skills);
        }
    }
}