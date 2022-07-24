using System;
using UnityEngine;

namespace Maze.Character.Player
{
    public class PlayerAnimator : MonoBehaviour
    {

        public Animator animator;
        public Character controller;
        
        private readonly int Walking = Animator.StringToHash("Walking");

        private void Update()
        {
            WalkingAnimation();
        }

        private void WalkingAnimation()
        {
            Vector3 velocity = controller.GetVelocity();
            bool isWalking = velocity.sqrMagnitude > 0;
            
            
            animator.SetBool(Walking, isWalking);
        }
    }
}
