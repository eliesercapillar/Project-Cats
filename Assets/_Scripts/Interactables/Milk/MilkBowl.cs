using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class MilkBowl : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _maxCapacity = 500f;
    private float _currentAmount = 0f;

    private PlayerResources _currentPlayer = null;
    private bool _interacting = false;
    private float _pourRate = 0f;

    private void Update()
    {
        if (_interacting)
        {
            //TODO: when the playerResource is maxed (100) and the player
            //      attempts to fill bowl and use all of their resource,
            //      because of delta, it will result in _currentAmount to be filled to 100.022... etc etc
            //      that is, small floating point imprecisions. Fix in future.
            //      A resource count of 100 should only fill the bowl by 100. 
            float delta = _pourRate * Time.deltaTime;
            if(_currentPlayer.TryPourMilk(delta))
            {
                _currentAmount = Mathf.Clamp(_currentAmount + delta, 0, _maxCapacity);
            }
        }
    }

    public void StartInteract(GameObject player, float pourRate)
    {
        Debug.Log($"Starting Bowl Interact");
        _currentPlayer = player.GetComponent<PlayerResources>();
        if (_currentPlayer == null) throw new ArgumentNullException();

        _interacting = true;
        _pourRate = pourRate;
    }

    public void StopInteract()
    {
        Debug.Log($"Ending Bowl Interact");
        _currentPlayer = default;
        _interacting = default;
        _pourRate = default;
    }
}
