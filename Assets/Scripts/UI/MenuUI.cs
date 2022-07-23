using System;
using Maze.Enums;
using Maze.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Maze.UI
{
    [DisallowMultipleComponent]
    public class MenuUI : MonoBehaviour
    {
        [Header("Buttons")] 
        public Button btn_play;
        public Button btn_exit;

        private void Awake()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            btn_play.onClick.AddListener(() => SceneController.Instance.LoadAsyncScene(SceneIndex.Gameplay));
            btn_exit.onClick.AddListener(Application.Quit);
        }
    }
}