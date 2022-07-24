using UnityEngine;

namespace Maze.ScriptableObejcts
{
    [CreateAssetMenu(fileName = "new Character Properties", menuName = "Character/ Properties", order = 0)]
    public class CharacterProperties : ScriptableObject
    {
        [Header("Movement Properties")] 
        public float Speed;

        [Header("Rotation Properties")] 
        public float RotationSpeed;
        public float RotationSmoothTime;
    }
}