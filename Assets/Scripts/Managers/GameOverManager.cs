namespace ProjectEON.Managers
{
    using UnityEngine;

    public class GameoverManager : MonoBehaviour
    {
        private GameManager _gameManager;

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void Gameover()
        {
#if DEBUG
            Debug.Log("GAMEOVER");
#endif
            Application.Quit(); // TO DO -> Application quit to change with Game over scene switch
        }
    }
}