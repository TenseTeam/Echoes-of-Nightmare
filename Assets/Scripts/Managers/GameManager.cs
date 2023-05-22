namespace ProjectEON.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Managers;
    using Extension.Generic.Camera;

    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField, Header("Gameplay Managers")]
        public CombatManager CombatManager { get; private set; }
        [field: SerializeField]
        public GameoverManager GameoverManager { get; private set; }
        [field: SerializeField, Header("Camera")]
        public CameraSwapperManager SwapCamera { get; private set; }
        [field: SerializeField]
        public Fade Fade { get; private set; }

        [field: SerializeField, Header("UI Manager")]
        public UIManager UIManager { get; private set; }

        [field: SerializeField, Header("Inputs Manager")]
        public InputManager InputManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            SwapCamera.Init(Fade);
            GameoverManager.Init(this);
        }

        private void OnEnable()
        {
            CombatManager.SetGameoverConditions(
                () => GameoverManager.PlayerVictory(),
                () => GameoverManager.Gameover()
            );
        }
    }
}