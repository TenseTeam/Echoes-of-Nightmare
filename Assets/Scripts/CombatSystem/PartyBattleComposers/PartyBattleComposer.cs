namespace ProjectEON.CombatSystem.PartyComposers
{
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.PartySystem;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Pools;
    using System;
    using ProjectEON.CombatSystem.Managers;

    public class PartyBattleComposer : MonoBehaviour
    {
        public List<Unit> ComposedUnits { get; private set; }

        [SerializeField, Header("Setup")] private Transform _parent;
        [SerializeField] private float _spaceBetweenEachOther;
        [SerializeField, Header("Pools")] protected UnitsPool Pool;

        private void Awake()
        {
            ComposedUnits = new List<Unit>();
        }

        public void ComposeUnits(Party party)
        {
            Vector3 startingPoint = _parent.position;

            foreach (UnitData unitData in party.UnitsData)
            {
                GameObject pooledUnit = Pool.Get();

                if (pooledUnit.TryGetComponent(out Unit unit))
                {
                    GenerateUnit(unit, unitData, startingPoint);
                    startingPoint = new Vector3(startingPoint.x + _spaceBetweenEachOther, startingPoint.y, startingPoint.z);
                }
            }
        }

        protected virtual void GenerateUnit(Unit unit, UnitData unitData, Vector3 position)
        {
            unit.Init(unitData, Pool);
            ComposedUnits.Add(unit);
            SetUnitBattleName(unit);
            SetUnitBattlePosition(unit, position);
        }

        protected void SetUnitBattlePosition(Unit unit, Vector3 position)
        {
            unit.transform.SetParent(_parent);
            unit.transform.position = position;
        }

        protected void SetUnitBattleName(Unit unit)
        {
            unit.transform.name = $"Unit {unit.Data.UnitName}";
            unit.transform.name = unit.Data.UnitName;
        }
    }
}