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
            Application.Quit(); // TO DO -> Application quit to change with Game over scene switch
        }
    }
}