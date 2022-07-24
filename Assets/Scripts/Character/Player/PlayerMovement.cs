using UnityEngine;

namespace Maze.Character.Player
{
    [RequireComponent(typeof(PlayerMovementBase))]
    public class PlayerMovement : Character
    {

        public Transform playerCamera;

        private PlayerMovementBase _movementBase;
        private InputController _inputController;

        private Vector3 storedVelocity;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (playerCamera == null)
                    playerCamera = Camera.main.transform;

            _inputController = InputController.Instance;
            _movementBase = GetComponent<PlayerMovementBase>();
        }

        private void FixedUpdate()
        {
            Vector3 velocity = MovementVelocity();
            _movementBase.SetVelocity(velocity);
            storedVelocity = velocity;
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
            return storedVelocity;
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