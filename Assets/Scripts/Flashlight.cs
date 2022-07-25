using System;
using UnityEngine;

namespace Maze
{
    [RequireComponent(typeof(Light))]
    public class Flashlight : MonoBehaviour
    {

        [SerializeField] private Light pointLight;
        public float criticalBatteryRatio;

        private bool isActive;

        private void Update()
        {
            if (InputController.Instance.LBMButton)
            {
                isActive = !isActive;
            }
            
            if (isActive)
            {
                TurnOn();
            }
            else
            {
                TurnOff();
            }
        }

        public void TurnOn()
        {
            pointLight.enabled = true;
        }

        public void TurnOff()
        {
            pointLight.enabled = false;
        }

    }
}