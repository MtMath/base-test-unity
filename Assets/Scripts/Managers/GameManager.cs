using Maze.Enums;
using Maze.Generics;

namespace Maze.Managers
{
    public class GameManager : Singleton<GameManager>
    {

        private GameStates _currentGameStates;
        
        public delegate void GameDelegate();
        public static event GameDelegate OnStartGame;
        public static event GameDelegate OnGameOver;
        public static event GameDelegate OnWinGame;


        private void Start()
        {
            _currentGameStates = GameStates.Running;
            OnStartGame?.Invoke();
            OnStartGame = null;
        }
        
        public void WinGame()
        {
            _currentGameStates = GameStates.WinGame;
            OnWinGame?.Invoke();
            OnWinGame = null;
        }

        public void GameOver()
        {
            _currentGameStates = GameStates.GameOver;
            
            OnGameOver?.Invoke();
            OnGameOver = null;

        }
        
        
    }
}
