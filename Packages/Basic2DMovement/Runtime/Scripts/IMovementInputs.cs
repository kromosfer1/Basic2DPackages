using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KromosGames.Basic2dMovement
{
    public interface IMovementInputs
    {
        public float HorizontalAxis { get; }
        public bool JumpInput { get; }
    }
}
