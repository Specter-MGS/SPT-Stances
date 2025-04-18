// --- File: StanceInput.cs ---
using UnityEngine;

namespace SPTStances.Core
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