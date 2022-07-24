using UnityEngine;

namespace Maze
{
    [RequireComponent(typeof(Light))]
    public class Flashlight : MonoBehaviour
    {

        private Light pointLight;

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