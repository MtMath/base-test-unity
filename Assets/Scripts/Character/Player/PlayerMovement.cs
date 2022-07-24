using UnityEngine;

namespace Maze.Character.Player
{
    public class PlayerMovement : Character
    {

        private Transform playerCamera;
        private InputController _inputController;

        private void Awake()
        {
            if (Camera.main != null) 
                playerCamera = Camera.main.transform;

            _inputController = InputController.Instance;
        }
        private Vector3 MovementDirection()
        {
            Vector3 velocity = Vector3.zero;
            Vector2 inputs = SetClampAxis(_inputController.MovementValue);

            if (playerCamera != null)
            {
                velocity += Vector3.ProjectOnPlane(playerCamera.right, playerCamera.up).normalized * inputs.x;
                velocity += Vector3.ProjectOnPlane(playerCamera.forward, playerCamera.up).normalized * inputs.y;
            }
            
            velocity.Normalize();

            return velocity;
        }
        private Vector3 MovementVelocity()
        {
            Vector3 _velocity = MovementDirection();
            _velocity *= CharacterProperties.Speed;

            return _velocity;
        }
        
        public override Vector3 GetVelocity()
        {
            throw new System.NotImplementedException();
        }

        public override Vector3 GetMovementVelocity()
        {
            throw new System.NotImplementedException();
        }
        
        private Vector2 SetClampAxis(Vector2 value)
        {
            return new Vector2(Mathf.Clamp(value.x, -1f, 1f), Mathf.Clamp(value.y, -1f, 1f));
        }
    }
}