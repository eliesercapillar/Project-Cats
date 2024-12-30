using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [Header("Camera Properties")]
    [SerializeField] private float _yClampAngleMin = -80f;
    [SerializeField] private float _yClampAngleMax = 80f;
    [Space(5)]
    [SerializeField] private float _aimSpeedX = 10f;
    [SerializeField] private float _aimSpeedY = 10f;

    private Vector3 _startingRotation;
    private Vector2 _lookInputDelta;

    private void Start()
    {
        InputManager.Instance.InputReader.Event_Look += HandleLook;
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (!vcam.Follow) return;
        if (stage != CinemachineCore.Stage.Aim) return;

        if (_startingRotation == null) _startingRotation = transform.localRotation.eulerAngles;
        _startingRotation.x += _lookInputDelta.x * _aimSpeedX * Time.deltaTime;
        _startingRotation.y += _lookInputDelta.y * _aimSpeedY * Time.deltaTime * -1;
        _startingRotation.y = Mathf.Clamp(_startingRotation.y, _yClampAngleMin, _yClampAngleMax);
        state.RawOrientation = Quaternion.Euler(_startingRotation.y, _startingRotation.x, 0f);
    }


    // Event Handler Methods
    private void HandleLook(Vector2 delta) => _lookInputDelta = delta;
}
