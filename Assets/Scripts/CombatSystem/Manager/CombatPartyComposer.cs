namespace ProjectEON.CombatSystem
{
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Pools;

    public class CombatPartyComposer : MonoBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private float _spaceBetweenEachOther;

        public void ComposeFightUnits(Party party)
        {
            List<Unit> combs = new List<Unit>();

            Vector3 startingPoint = _parent.position;

            foreach(Unit unit in party.Units)
            {
                unit.transform.SetParent(_parent);
                unit.transform.position = startingPoint;
                unit.transform.name = unit.Data.unitName;
                startingPoint = new Vector3(startingPoint.x + _spaceBetweenEachOther, startingPoint.y, startingPoint.z);
            }
        }
    }
}