namespace ProjectEON.PartySystem
{
    using ProjectEON.CombatSystem;
    using ProjectEON.CombatSystem.Manager;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;

    public class Party : MonoBehaviour
    {
        [field: SerializeField]
        public List<UnitData> PartyMembersData { get; private set; }
        public List<Unit> Units { get; private set; }

        private void Awake()
        {
            Units = new List<Unit>();
        }

        public void BuildParty()
        {
            UnitsPool pool = CombatManager.Instance.UnitsPool;

            foreach (UnitData combData in PartyMembersData)
            {
                GameObject pooledUnit = pool.Get();

                if (pooledUnit.TryGetComponent(out Unit unit))
                {
                    unit.Init(combData, pool);
                    Units.Add(unit);
                }
            }
        }
    }
}
