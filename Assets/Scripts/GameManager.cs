namespace ProjectEON.Managers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.Singleton;

    public class GameManager : Singleton<GameManager>
    {  
        //private CombatManager m_CombatManager
        //public CombatManager CombatManager { get => test;}

        private void Start()
        {
            //m_CombatManager = GetComponentInChildren(CombatManager);
        }


    }
}