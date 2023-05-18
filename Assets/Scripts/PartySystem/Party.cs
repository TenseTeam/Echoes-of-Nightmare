namespace ProjectEON.PartySystem
{
    using UnityEngine;
    using System.Collections.Generic;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem;
    using ProjectEON.CombatSystem.Managers;

    public abstract class Party : MonoBehaviour
    {
        [field: SerializeField]
        public List<UnitData> UnitsData { get; private set; }

        private InFightUnitsManager _relatedInFightUnitManager;

        public void AssociateInFightUnitsManager(InFightUnitsManager inFightUnitsManager)
        {
            _relatedInFightUnitManager = inFightUnitsManager;
        }

        public List<UnitManager> GetComposedUnits()
        {
            return _relatedInFightUnitManager.GetComposedUnits();
        }

        public bool AreThereMembersAlive()
        {
            return _relatedInFightUnitManager.GetComposedUnits().Count > 0;
        }
    }
}