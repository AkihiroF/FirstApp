using System;
using UnityEngine;

namespace Resource.Scripts
{
    public class MovingPlayer : MonoBehaviour
    {
        private Rigidbody _rb;

        private Vector3 _moveDirection;
        private CapsuleCollider _colliderBody;

        private bool enable = true;
        

        public LayerMask groundlayer;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _colliderBody = GetComponent<CapsuleCollider>();
            InputManager.Moving += MoveBody;
            InputManager.Rotate += RotateBody;
            InputManager.Jump += JumpBody;

            InputManager.EnableMoving += OnMoving;
        }

        private void MoveBody(float speed)
        {
            if(!CheckGround()) return;
            var mnog = speed > 0 ? 1 : -1;
            _moveDirection = transform.forward * mnog;
            _rb.AddForce(_moveDirection.normalized * Math.Abs(speed), ForceMode.Force);
        }

        private void RotateBody(float speed)
        {
            if(!CheckGround()) return;
            var mnog = speed > 0 ? -1 : 1;
            _moveDirection = transform.right * mnog;
            _rb.AddForce(_moveDirection.normalized * Math.Abs(speed), ForceMode.Force);
        }

        private void JumpBody(float force)
        {
            if (CheckGround())
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
                _rb.AddForce(transform.up * force, ForceMode.Impulse);
            }
        }

        private bool CheckGround()
        {
            return Physics.Raycast(transform.position, Vector3.down, _colliderBody.height / 2 + 0.1f, groundlayer);
        }

        private void OnMoving(float ss)
        {
            if (ss == 0)
            {
                InputManager.Moving -= MoveBody;
                InputManager.Rotate -= RotateBody;
                InputManager.Jump -= JumpBody;
                enable = false;
            }
            else
            {
                if(enable) return;
                InputManager.Moving += MoveBody;
                InputManager.Rotate += RotateBody;
                InputManager.Jump += JumpBody;
                enable = true;
            }
        }
    }
}
