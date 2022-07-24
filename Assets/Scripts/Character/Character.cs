using Maze.ScriptableObejcts;
using UnityEngine;
using UnityEngine.AI;

namespace Maze.Character
{
    public abstract class Character : MonoBehaviour
    {
        public CharacterProperties CharacterProperties;
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

        public abstract Vector3 GetVelocity();
        public abstract Vector3 GetMovementVelocity();
    }
}