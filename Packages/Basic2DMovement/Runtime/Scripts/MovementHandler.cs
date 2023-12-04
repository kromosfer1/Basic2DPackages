using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KromosGames.Basic2dMovement
{
    public class MovementHandler : MonoBehaviour
    {
        IMovementInputs movementInputs;

        [SerializeField] private Rigidbody2D _rb;

        [Range(0,50)][SerializeField] private float _movementSpeed;

        [SerializeField] private float _jumpPower;
        [SerializeField] private int _jumpCount;
        [SerializeField] private int _maxJumpCount;

        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private Transform _groundCheckTransform;
        private bool isGrounded;

        private void Awake()
        {
            movementInputs = GetComponent<IMovementInputs>();
        }

        private void Update()
        {
            Movement();
            PlayerInput();
            GroundCheck();
        }

        private void Movement()
        {
            transform.Translate(new Vector2(movementInputs.HorizontalAxis, 0) * _movementSpeed * Time.deltaTime);
        }

        private void PlayerInput()
        {
            if (movementInputs.JumpInput)
            {
                JumpHandler();
            }
        }

        private void JumpHandler()
        {
            _jumpCount--;

            if (_jumpCount > 0)
            {
                JumpAction();
            }
            else if (_jumpCount == 0 && isGrounded)
            {
                JumpAction();
            }
        }

        private void JumpAction()
        {
            _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }

        private void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(_groundCheckTransform.position, 0.15f, _groundLayerMask);

            if (isGrounded)
                _jumpCount = _maxJumpCount;
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_groundCheckTransform.position, 0.15f);
        }
    }
}
