namespace ProjectEON.CombatSystem.Units.CardsSystem
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class UnitDeck : MonoBehaviour
    {
        public List<SkillData> CardDatas { get; private set; }

        public void Init (List<SkillData> _defaultCardDatas)
        {
            CardDatas = _defaultCardDatas.ToList(); // ToList() creates a new List with the same elements
        }
    }
}