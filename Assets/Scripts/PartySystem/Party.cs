namespace ProjectEON.PartySystem
{
    using UnityEngine;
    using System.Collections.Generic;
    using Extension.Patterns.ObjectPool;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.CombatSystem.Manager;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.SOData;

    public class Party : MonoBehaviour
    {
        [field: SerializeField]
        public List<UnitData> PartyMembersData { get; private set; }
        public List<Unit> Units { get; private set; }

        private void Awake()
        {
            Units = new List<Unit>();
        }

        public virtual void BuildParty()
        {
            foreach (UnitData unitData in PartyMembersData)
            {
                GenerateUnit(unitData);
            }
        }

        public void BuildParty(List<UnitData> memebrsData)
        {
            PartyMembersData = memebrsData;
            BuildParty();
        }

        protected virtual void GenerateUnit(UnitData unitData)
        {
            GameObject pooledUnit = CombatManager.Instance.UnitsPool.Get();

            if (pooledUnit.TryGetComponent(out Unit unit))
            {
                unit.Init(unitData, CombatManager.Instance.UnitsPool);
                Units.Add(unit);
            }
        }
    }
}