// --- File: StanceInput.cs ---
using UnityEngine;

namespace Core
{
    public class StanceInput : MonoBehaviour
    {
        private KeyCode toggleKey = KeyCode.Y;

        void Update()
        {
            if (Input.GetKeyDown(toggleKey))
            {
                StanceController.CycleStance();
            }
        }
    }
}