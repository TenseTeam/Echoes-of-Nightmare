namespace ProjectEON.Managers
{
    using UnityEngine;

    public class PhaseSwapperManager : MonoBehaviour
    {
        [SerializeField]
        private Camera _exploringCamera;
        [SerializeField]
        private Camera _combatCamera;
        private GameManager _gameManager;

        /// <summary>
        /// Initializes this <see cref="PhaseSwapperManager"/>.
        /// </summary>
        /// <param name="gameManager">Related <see cref="GameManager"/>.</param>
        /// <param name="hasExploringCameraPriority">Camera priority.</param>
        public void Init(GameManager gameManager, bool hasExploringCameraPriority = true)
        {
            _gameManager = gameManager;
            _exploringCamera.enabled = hasExploringCameraPriority;
            _combatCamera.enabled = !hasExploringCameraPriority;

            _gameManager.Fade.OnFadeInEnd += SwapPhase;
        }

        private void OnDisable()
        {
            _gameManager.Fade.OnFadeInEnd -= SwapPhase;
        }

        /// <summary>
        /// Swap the phases bewteen combat and exploring.
        /// </summary>
        private void SwapPhase()
        {
            _exploringCamera.enabled = !_exploringCamera.enabled;
            _combatCamera.enabled = !_combatCamera.enabled;
            _gameManager.UIManager.SetActiveWorldUI(_exploringCamera.enabled);

            if (_exploringCamera.enabled)
                _gameManager.InputManager.WorldInputEnable();
            else
                _gameManager.InputManager.BattleInputEnable();
        }
    }
}
