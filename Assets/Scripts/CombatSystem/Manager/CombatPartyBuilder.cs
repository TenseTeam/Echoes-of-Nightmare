namespace ProjectEON.CombatSystem.StateMachines
{
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Manager;
    using ProjectEON.CombatSystem.Pools;

    public class CombatPartyBuilder : MonoBehaviour
    {
        public List<Unit> BuildCombatants(Party party, UnitsPool pool, Transform parent, float spaceBetweenEachOther)
        {
            List<Unit> combs = new List<Unit>();

            Vector3 startingPoint = parent.position;

            foreach(UnitData combData in party.PartyMembers)
            {
                GameObject combatantGO = pool.Get(parent);
                combatantGO.transform.position = startingPoint;

                if(combatantGO.TryGetComponent(out Unit combatant))
                {
                    combatant.Init(combData, pool);
                    combs.Add(combatant);
                }

                startingPoint = new Vector3(startingPoint.x + spaceBetweenEachOther, startingPoint.y, startingPoint.z);
            }

            return combs;
        }
    }
}