namespace ProjectEON.Managers
{
    using UnityEngine;

    public class GameoverManager : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        public void PlayerVictory()
        {
#if DEBUG
            Debug.Log("Player won the fight!");
#endif
            _gameManager.SwapCamera.SwapToExplore();
            _gameManager.UIManager.SetActiveWorldUI(true);
            _gameManager.InputManager.WorldInputEnable();
        }

        public void Gameover()
        {
#if DEBUG
            Debug.Log("Gameover!");
#endif
            //_gameManager.SwapCamera.SwapToExplore();
            Application.Quit(); // TO DO -> Application quit to change with Game over scene switch.
        }
    }
}