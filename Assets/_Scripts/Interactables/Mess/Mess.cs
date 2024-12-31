using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class Mess : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _requiredProgress = 100f;
    private Observer<float> _currentProgress = new Observer<float>(0f);

    private bool _interacting = false;
    private float _sweepRate = 0f;

    public Observer<float> CurrentProgress { get {return _currentProgress;} }

    private void Awake()
    {
        ServiceLocator.Global.Register(this);
    }

    private void Update()
    {
        if (_interacting)
        {
            //TODO: when the playerResource is maxed (100) and the player
            //      attempts to fill bowl and use all of their resource,
            //      because of delta, it will result in _currentAmount to be filled to 100.022... etc etc
            //      that is, small floating point imprecisions. Fix in future.
            //      A resource count of 100 should only fill the bowl by 100. 
            float delta = _sweepRate * Time.deltaTime;
            _currentProgress.Value = Mathf.Clamp(_currentProgress.Value + delta, 0, _requiredProgress);
            if (_currentProgress.Value >= _requiredProgress) Destroy(gameObject); // TODO: Animation
        }
    }

    public void StartInteract(GameObject player, float sweepRate)
    {
        Debug.Log($"Starting Bowl Interact");

        _interacting = true;
        _sweepRate = sweepRate;
    }

    public void StopInteract()
    {
        Debug.Log($"Ending Bowl Interact");
        _interacting = default;
        _sweepRate = default;
    }
}
