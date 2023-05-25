namespace ProjectEON.Managers
{
    using UnityEngine;
    using Extension.Patterns.Singleton;
    using ProjectEON.CombatSystem.Managers;
    using Extension.Generic.Camera;
    using ProjectEON.PartySystem;

    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField, Header("Gameplay Managers")]
        public CombatManager CombatManager { get; private set; }
        [field: SerializeField]
        public GameoverManager GameoverManager { get; private set; }
        [field: SerializeField, Header("Camera")]
        public PhaseSwapperManager PhaseSwapperManager { get; private set; }
        [field: SerializeField]
        public Fade Fade { get; private set; }

        [field: SerializeField, Header("Audio")]
        public AudioManager AudioManager { get; private set; }

        [field: SerializeField, Header("UI Manager")]
        public UIManager UIManager { get; private set; }

        [field: SerializeField, Header("Inputs Manager")]
        public InputManager InputManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            PhaseSwapperManager.Init(this);
            GameoverManager.Init(this);
            CombatManager.BuildPlayerParty();
            UIManager.UIRoasterManager.InitializeRoasterUI();
        }

        private void OnEnable()
        {
            CombatManager.Init(
                () => 
                {
                    AudioManager.PlayBattle();
                    Fade.DoFadeInOut(); // The PhaseSwapManager has subscribed to the delegates of the Fade
                },
                () =>
                {
                    AudioManager.PlayTheme();
                    Fade.DoFadeInOut();
                },
                () =>
                {
                    GameoverManager.Gameover();
                }
            );
        }
    }
}