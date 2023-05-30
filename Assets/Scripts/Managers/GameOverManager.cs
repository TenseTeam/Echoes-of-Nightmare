namespace ProjectEON.Managers
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class GameoverManager : MonoBehaviour
    {
        private GameManager _gameManager;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        /// <summary>
        /// Gameovers the game.
        /// </summary>
        public void Gameover()
        {
#if DEBUG
            Debug.Log("GAMEOVER!");
#endif
            SceneManager.LoadScene("scn_Gameover", LoadSceneMode.Single);
        }
    }
}