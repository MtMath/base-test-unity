using UnityEngine;
using UnityEngine.AI;

namespace Maze.Character.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMovementBase : MonoBehaviour
    {
        public NavMeshAgent nav { get; private set; }

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            nav = GetComponent<NavMeshAgent>();
        }
        
        public void SetVelocity(Vector3 velocity)
        {
            if(velocity == Vector3.zero) return;
            Vector3 destination = velocity;
            
            nav.Move(destination * Time.deltaTime);
        }
    }
}