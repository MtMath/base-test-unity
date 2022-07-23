using Maze.Enums;
using Maze.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Maze.UI
{
    public class PauseMenuUI : MonoBehaviour
    {

        [Header("Open Panel Button")] 
        public Button btn_menu;
        
        [Header("Panel Buttons")] 
        public Button btn_Resume;
        public Button btn_Restart;
        public Button btn_BackToMenu;
        public Button btn_BackToDesktop;
        
        [Header("Canvas Group")]
        public CanvasGroup canvasGroup;

        private void Awake()
        {
            InitializeButton();
        }
        private void InitializeButton()
        {
            SceneController cachedSceneController = SceneController.Instance;
            
            btn_menu.onClick.AddListener(ShowPanel);
            btn_Resume.onClick.AddListener(HidePanel);
            btn_Restart.onClick.AddListener(cachedSceneController.ReloadScene);
            btn_BackToDesktop.onClick.AddListener(cachedSceneController.Quit);
            btn_BackToMenu.onClick.AddListener(() => cachedSceneController.LoadAsyncScene(SceneIndex.Main));
        }

        private void ShowPanel()
        {
            canvasGroup.alpha = 1f;
        }

        private void HidePanel()
        {
            canvasGroup.alpha = 0f;
        }
    }
}
