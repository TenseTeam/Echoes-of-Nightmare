namespace ProjectEON.Managers
{
    using Extension.Generic.Camera;
    using UnityEngine;

    public class PhaseSwapperManager : MonoBehaviour
    {
        [SerializeField]
        private Camera _exploringCamera, _combatCamera;
        private GameManager _gameManager;

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

        private void SwapPhase()
        {
            _exploringCamera.enabled = !_exploringCamera.enabled;
            _combatCamera.enabled = !_combatCamera.enabled;
            //_gameManager.UIManager.SetActiveWorldUI(_exploringCamera.enabled); Commented for testing

            if (_exploringCamera.enabled)
                _gameManager.InputManager.WorldInputEnable();
            else
                _gameManager.InputManager.BattleInputEnable();
        }
    }
}
