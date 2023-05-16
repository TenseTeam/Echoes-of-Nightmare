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

    public abstract class PartyBattleComposer<T> : MonoBehaviour where T : UnitManager
    {
        [SerializeField, Header("Pools")]
        protected UnitsPool Pool;

        [SerializeField, Header("Setup")]
        private Transform _parent;
        [SerializeField]
        private float _spaceBetweenEachOther;

        [field: SerializeField, Header("Manager")]
        public InFightUnitsManager InFightUnitsManager { get; protected set; }

        public void ComposeUnits(Party party)
        {
            Vector3 startingPoint = _parent.position;

            foreach (UnitData unitData in party.UnitsData)
            {
                GameObject pooledUnit = Pool.Get();

                if (pooledUnit.TryGetComponent(out T unit))
                {
                    GenerateUnit(unit, unitData, party, startingPoint);
                    startingPoint = new Vector3(startingPoint.x + _spaceBetweenEachOther, startingPoint.y, startingPoint.z);
                }
            }
        }

        protected virtual void GenerateUnit(T unitManager, UnitData unitData, Party relatedParty, Vector3 position)
        {
            unitManager.Init(unitData, relatedParty, Pool);
            InFightUnitsManager.Add(unitManager);
            SetUnitBattleName(unitManager);
            SetUnitBattlePosition(unitManager, position);
        }

        protected void SetUnitBattlePosition(UnitManager unit, Vector3 position)
        {
            unit.transform.SetParent(_parent);
            unit.transform.position = position;
        }

        protected void SetUnitBattleName(UnitManager unit)
        {
            unit.transform.name = $"Unit {unit.UnitData.UnitName}";
            unit.transform.name = unit.UnitData.UnitName;
        }
    }
}