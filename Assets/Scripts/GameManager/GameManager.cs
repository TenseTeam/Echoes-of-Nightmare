namespace ProjectEON.Managers
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Managers;

    [RequireComponent(typeof(SwapCamera))]
    public class GameManager : Singleton<GameManager>
    {
        public SwapCamera SwapCamera { get; private set; }
        public CombatManager CombatManager { get; private set; }
        public UIManager UIManager { get; private set; }
        public InputManager InputManager { get; private set; }
        public GameOverManager GameOverManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            SwapCamera = GetComponent<SwapCamera>();
            CombatManager = GetComponentInChildren<CombatManager>();
            UIManager = GetComponentInChildren<UIManager>();
            InputManager = GetComponentInChildren<InputManager>();
            GameOverManager = GetComponentInChildren<GameOverManager>();
        }

        private void OnEnable()
        {
            CombatManager.SetGameoverConditions(
                () => GameOverManager.PlayerVictory(),
                () => GameOverManager.Gameover()
            );
        }
    }
}