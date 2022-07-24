using System;
using UnityEngine;

namespace Maze.Character.Player
{
    public class TurnTowardController : MonoBehaviour
    {
        public Character character;
        private float _turnReference;
        
        private void LateUpdate()
        {
            var velocity = character.GetVelocity();
            
            if(velocity.sqrMagnitude > 0)
                RotationAngle(velocity);
        }

        private void Rotation(Vector3 input)
        {
            Quaternion lookRotation = Quaternion.LookRotation(input, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 720 * Time.deltaTime);
        }

        private void RotationAngle(Vector3 input)
        {
            var properties = character.CharacterProperties;
            
            float angle = Mathf.Atan2(input.x, input.z) * ( 180 / Mathf.PI );
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref _turnReference,
                properties.RotationSmoothTime * properties.RotationSpeed);

            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f); 
        }
    }
}