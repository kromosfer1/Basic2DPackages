using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KromosGames.Basic2dMovement
{
    public class PCMovementInputs : MonoBehaviour, IMovementInputs
    {
        public float HorizontalAxis { get; private set; }

        public bool JumpInput { get; private set; }

        private void Update()
        {
            GetInputs();
        }

        private void GetInputs()
        {
            HorizontalAxis = Input.GetAxis("Horizontal");
            JumpInput = Input.GetKeyDown(KeyCode.Space);
        }
    }
}
