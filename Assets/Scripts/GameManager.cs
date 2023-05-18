namespace ProjectEON.Managers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Managers;

    public class GameManager : Singleton<GameManager>
    {
        private CombatManager m_CombatManager;
        public SwapCamera m_SwapCamera;
        public CombatManager CombatManager { get => m_CombatManager; }
        public SwapCamera SwapCamera { get => m_SwapCamera; }
        
        
        protected override void Awake()
        {
            base.Awake();
            m_CombatManager = GetComponent<CombatManager>();
            m_SwapCamera = GetComponent<SwapCamera>();
        }
    }
}