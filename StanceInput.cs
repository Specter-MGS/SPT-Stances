using UnityEngine;

namespace SPTStances
{
    public class StanceInput : MonoBehaviour
    {
        private KeyCode toggleKey = KeyCode.Y; // Default stance toggle key

        void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                StanceController.CycleStance();
            }
        }
    }
}