using UnityEngine;

namespace Maze.Generics
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private Singleton(){}

        private static T _instance;

        public static T Instance
        {
            get
            {
                lock (_instance)
                {
                    Initialize();
                    return _instance;
                }
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            if (IsNull())
            {
                _instance = FindObjectOfType<T>();
                
                if (IsNull())
                {
                    GameObject singletonObject = new GameObject(typeof(T) + " (Singleton)");
                    singletonObject.hideFlags = HideFlags.NotEditable;
                    
                    _instance = singletonObject.AddComponent<T>();
                    
                    DontDestroyOnLoad(singletonObject);
                }
                
            }
        }

        private void Awake()
        {
            if (!IsNull())
            {
                DontDestroyOnLoad(this);
            }
        }

        private static bool IsNull()
        {
            lock (_instance)
            {
                return _instance == null && _instance.Equals(null);
            }
        }
    }
}