namespace ProjectEON.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Managers;

    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField, Header("Gameplay Managers")]
        public CombatManager CombatManager { get; private set; }
        [field: SerializeField]
        public CameraSwapperManager SwapCamera { get; private set; }
        [field: SerializeField]
        public GameoverManager GameoverManager { get; private set; }

        [field: SerializeField, Header("UI Manager")]
        public UIManager UIManager { get; private set; }

        [field: SerializeField, Header("Inputs Manager")]
        public InputManager InputManager { get; private set; }

        private void OnEnable()
        {
            CombatManager.SetGameoverConditions(
                () => GameoverManager.PlayerVictory(),
                () => GameoverManager.Gameover()
            );
        }
    }
}