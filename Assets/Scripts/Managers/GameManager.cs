using System;
using Maze.Enums;
using UnityEngine;

namespace Maze.Managers
{
    public class GameManager : MonoBehaviour
    {

        private GameStates _currentGameStates;
        
        public delegate void GameDelegate();
        public static event GameDelegate OnStartGame;
        public static event GameDelegate OnGameOver;
        public static event GameDelegate OnWinGame;


        private void Awake()
        {
            _currentGameStates = GameStates.Running;
        }

        public void WinGame()
        {
            _currentGameStates = GameStates.WinGame;
        }

        public void GameOver()
        {
            _currentGameStates = GameStates.GameOver;
        }
        
        
    }
}
