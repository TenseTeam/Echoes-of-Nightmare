namespace ProjectEON.SOData
{
    using System.Collections.Generic;
    using UnityEngine;

    //[System.Serializable]
    //public struct Phase
    //{
    //    public UnitData unitData;
    //}

    [CreateAssetMenu(menuName = "Combat/Units/Boss")]
    public class BossData : UnitData
    {
        [Header("Boss Phases")]
        public List<UnitData> Phases;
    }
}