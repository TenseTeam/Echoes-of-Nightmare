namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.StateMachines;
    using ProjectEON.CombatSystem.PartyComposers;
    using ProjectEON.PartySystem;
    using System.Collections.Generic;
    using ProjectEON.CombatSystem.Units;

    public class InFightUnitsManager : MonoBehaviour
    {
        private List<UnitManager> _composedUnits;

        private void Awake()
        {
            _composedUnits = new List<UnitManager>();
        }

        /// <summary>
        /// Adds a <see cref="UnitManager"/>
        /// </summary>
        /// <param name="unit"></param>
        public void Add(UnitManager unit)
        {
            _composedUnits.Add(unit);
        }

        public void Remove(UnitManager unit)
        {
            _composedUnits.Remove(unit);
        }

        public void Clear()
        {
            _composedUnits.Clear();
        }

        public List<UnitManager> GetComposedUnits()
        {
            return _composedUnits;
        }
    }
}