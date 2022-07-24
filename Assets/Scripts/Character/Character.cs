using Maze.ScriptableObejcts;
using UnityEngine;

namespace Maze.Character
{
    public abstract class Character : MonoBehaviour
    {
        public CharacterProperties CharacterProperties;
        public abstract Vector3 GetVelocity();
        public abstract Vector3 GetMovementVelocity();
    }
}