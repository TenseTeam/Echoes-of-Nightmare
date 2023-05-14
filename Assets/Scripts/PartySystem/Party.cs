namespace ProjectEON.PartySystem
{
    using UnityEngine;
    using System.Collections.Generic;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem;

    public abstract class Party : MonoBehaviour
    {
        [field: SerializeField]
        public List<UnitData> UnitsData { get; private set; }

        public void BuildParty(List<UnitData> memebrsData)
        {
            UnitsData = memebrsData;
        }

        public abstract List<Unit> GetComposedUnits();
    }
}