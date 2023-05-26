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
        /// Adds a <see cref="UnitManager"/> to the composed units list.
        /// </summary>
        /// <param name="unit"></param>
        public void Add(UnitManager unit)
        {
            _composedUnits.Add(unit);
        }

        /// <summary>
        /// Removes a <see cref="UnitManager"/> from the units list.
        /// </summary>
        /// <param name="unit"></param>
        public void Remove(UnitManager unit)
        {
            _composedUnits.Remove(unit);
        }

        /// <summary>
        /// Clears the units list.
        /// </summary>
        public void Clear()
        {
            _composedUnits.Clear();
        }

        /// <summary>
        /// Gets the composed units.
        /// </summary>
        /// <returns>List of the composed units.</returns>
        public List<UnitManager> GetComposedUnits()
        {
            return _composedUnits;
        }
    }
}