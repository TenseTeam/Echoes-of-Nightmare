namespace ProjectEON.CombatSystem.PartyComposers
{
    using UnityEngine;
    using ProjectEON.PartySystem;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.CombatSystem.Managers;

    public abstract class PartyBattleComposer<T> : MonoBehaviour where T : UnitManager
    {
        [SerializeField, Header("Setup")]
        private Transform _parent;
        [SerializeField]
        private Vector3 _spaceBetweenEachOther;

        [field: SerializeField, Header("Manager")]
        public InFightUnitsManager InFightUnitsManager { get; protected set; }

        [SerializeField, Header("Pools")]
        protected UnitsPool Pool;

        public void ComposeUnits(Party party)
        {
            Vector3 startingPoint = _parent.position;

            foreach (UnitData unitData in party.UnitsData)
            {
                GameObject pooledUnit = PoolUnit(unitData);

                if (pooledUnit.TryGetComponent(out T unit))
                {
                    GenerateUnit(unit, unitData, party, startingPoint);
                    startingPoint += _spaceBetweenEachOther;
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

        protected virtual GameObject PoolUnit(UnitData unitData)
        {
            return Pool.Get();
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