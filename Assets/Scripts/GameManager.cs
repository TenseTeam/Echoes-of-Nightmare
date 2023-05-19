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
        public UIManager m_UIManager;
        public InputManager m_InputManager;
        public CombatManager CombatManager { get => m_CombatManager; }
        public SwapCamera SwapCamera { get => m_SwapCamera; }
        public UIManager UIManager { get => m_UIManager; }
        public InputManager InputManager { get => m_InputManager; }
        
        
        protected override void Awake()
        {
            base.Awake();
            m_CombatManager = GetComponent<CombatManager>();
            m_SwapCamera = GetComponent<SwapCamera>();
            m_UIManager = GetComponentInChildren<UIManager>();
            m_InputManager = GetComponentInChildren<InputManager>();
        }
    }
}