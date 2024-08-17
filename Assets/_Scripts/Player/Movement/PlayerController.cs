using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody _rb;

        [Header("Movement Properties")]
        [SerializeField] private float _walkSpeed = 5;
        [SerializeField] private float _sprintSpeed = 10;
        [SerializeField] private float _jumpSpeed = 5;

        // Internal Properties & State Flags
        private Vector2 _movementInputDir;
        private bool _isJumping;
        private bool _isSprinting;

        private void Awake()
        {
            if (_rb == null) _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            // Subscribe to Gameplay Events
            InputManager.Instance.InputReader.Event_Move            += HandleMove;
            InputManager.Instance.InputReader.Event_Jump            += HandleJump;
            InputManager.Instance.InputReader.Event_JumpCancelled   += HandleJumpCancelled;
            InputManager.Instance.InputReader.Event_Sprint          += HandleSprint;
            InputManager.Instance.InputReader.Event_SprintCancelled += HandleSprintCancelled;
        }

        private void Update()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            if (_movementInputDir == Vector2.zero) return;
            if (_isSprinting) 
            {
                transform.position += new Vector3(_movementInputDir.x, 0, _movementInputDir.y) * _sprintSpeed * Time.deltaTime;
            }
            else 
            {
                transform.position += new Vector3(_movementInputDir.x, 0, _movementInputDir.y) * _walkSpeed * Time.deltaTime;
            }
        }

        private void Jump()
        {
            if (!_isJumping) return;

            transform.position += new Vector3(0, 1, 0) * _jumpSpeed * Time.deltaTime;
        }

        // Event Handler Methods
        private void HandleMove(Vector2 dir) => _movementInputDir = dir;
        private void HandleJump()            => _isJumping = true;
        private void HandleJumpCancelled()   => _isJumping = false;
        private void HandleSprint()          => _isSprinting = true;
        private void HandleSprintCancelled() => _isSprinting = false;

    }
}
