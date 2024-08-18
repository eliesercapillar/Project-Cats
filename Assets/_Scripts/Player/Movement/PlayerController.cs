using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;

        [Header("Dependencies")]
        private Camera _camera;

        [Header("Movement Properties")]
        [SerializeField] private float _walkSpeed = 2.0f;
        [SerializeField] private float _sprintSpeed = 5.0f;
        [SerializeField] private float _jumpHeight = 1.0f;
        [SerializeField] private float _gravity = -9.81f;

        // Internal Properties & State Flags
        private Vector3 _playerVelocity;
        private Vector2 _movementInputDir;
        private bool _isJumping, _isSprinting;

        private void Awake()
        {
            if (_characterController == null) _characterController = GetComponent<CharacterController>();
            if (_camera == null) _camera = Camera.main;
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
            JumpAndApplyGravity();
        }

        private void Move()
        {
            if (_movementInputDir == Vector2.zero) return;

            if (_characterController.isGrounded && _playerVelocity.y < 0) _playerVelocity.y = 0f;

            Vector3 direction = new Vector3(_movementInputDir.x, 0, _movementInputDir.y);
            direction = _camera.transform.forward * direction.z 
                      + _camera.transform.right * direction.x;
            direction.y = 0;

            float speed = _isSprinting ? _sprintSpeed : _walkSpeed;

            _characterController.Move(direction * Time.deltaTime * speed);
        }

        private void JumpAndApplyGravity()
        {
            if (_isJumping && _characterController.isGrounded) _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);

            _playerVelocity.y += _gravity * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }

        // Event Handler Methods
        private void HandleMove(Vector2 dir) => _movementInputDir = dir;
        private void HandleJump()            => _isJumping = true;
        private void HandleJumpCancelled()   => _isJumping = false;
        private void HandleSprint()          => _isSprinting = true;
        private void HandleSprintCancelled() => _isSprinting = false;

    }
}

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}