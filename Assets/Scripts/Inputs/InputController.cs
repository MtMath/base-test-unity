using System;
using Maze.Enums;
using Maze.Generics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Maze
{
    public class InputController : Singleton<InputController>
    {

        private PlayerInputs _inputs;

        public Vector2 MovementValue { get; private set; }
        public Vector2 LookValue { get; private set; }
        
        public bool RBMButton {get; private set;}
        public bool LBMButton {get; private set;}
        
        #region Unity Built-IN
        
        private void Awake()
        {
            _inputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            _inputs.Player.Enable();
            InputEvents();
        }

        private void OnDisable()
        {
            _inputs.Player.Disable();
            _inputs.Dispose();
        }

        #endregion

        private void InputEvents()
        {
            //Movement
            _inputs.Player.Movement.performed += UpdateMovement;
            _inputs.Player.Movement.canceled += UpdateMovement;

            //Mouse Position
            _inputs.Player.Look.performed += UpdateLook;
            _inputs.Player.Look.canceled += UpdateLook;
            
            //Mouse Buttons
            _inputs.Player.RBM.performed += UpdateRBM;
            _inputs.Player.RBM.performed += UpdateRBM;

            _inputs.Player.LBM.performed += UpdateLBM;
            _inputs.Player.LBM.canceled += UpdateLBM;
        }

        private void UpdateMovement(InputAction.CallbackContext context)
        {
            MovementValue = context.ReadValue<Vector2>();
            Debug.Log(MovementValue);
        }

        private void UpdateLook(InputAction.CallbackContext context)
        {
            LookValue = context.ReadValue<Vector2>();
        }

        private void UpdateRBM(InputAction.CallbackContext context)
        {
            RBMButton = context.ReadValueAsButton();
        }
        
        private void UpdateLBM(InputAction.CallbackContext context)
        {
            LBMButton = context.ReadValueAsButton();
        }

        public void EnableInput(InputActions action)
        {
            GetInputAction(action).Enable();
        }

        public void DisableInput(InputActions action)
        {
            GetInputAction(action).Disable();
        }

        private InputAction GetInputAction(InputActions action)
        {
            switch (action)
            {
                case InputActions.Movement:
                    return _inputs.Player.Movement;
                case InputActions.Look:
                    return _inputs.Player.Look;
                case InputActions.LBM:
                    return _inputs.Player.LBM;
                case InputActions.RBM:
                    return _inputs.Player.RBM;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }
    }
}
