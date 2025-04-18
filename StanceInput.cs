// --- File: StanceInput.cs ---
using UnityEngine;

namespace SPTStances
{
    public class StanceInput : MonoBehaviour
    {
        private KeyCode toggleKey = KeyCode.Y;

        void Update()
        {
            if (UnityEngine.Input.GetKeyDown(toggleKey))
            {
                StanceController.CycleStance();
            }
        }
    }
}