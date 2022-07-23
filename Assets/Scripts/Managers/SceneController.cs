using Maze.Enums;
using Maze.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maze.Managers
{
    public class SceneController : Singleton<SceneController>
    {
        public void LoadScene(SceneIndex sceneName)
        {
            SceneManager.LoadScene((int)sceneName, LoadSceneMode.Single);
        }

        public void LoadAsyncScene(SceneIndex sceneName)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Single);
        }
    }
}