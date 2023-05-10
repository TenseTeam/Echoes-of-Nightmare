namespace ProjectEON.PartySystem
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;

    public class Party : MonoBehaviour
    {
        [field: SerializeField]
        public List<UnitData> PartyMembers { get; private set; }
    }
}
