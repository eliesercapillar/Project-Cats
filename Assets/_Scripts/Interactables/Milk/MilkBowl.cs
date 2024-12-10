using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class MilkBowl : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _maxCapacity = 500f;
    private float _currentAmount = 0f;

    private bool _interacting = false;
    private float _pourRate;

    private void Update()
    {
        if (_interacting)
        {
            float delta = _pourRate * Time.deltaTime;
            //_currentBackpack = Mathf.Clamp(_currentBackpack - delta, 0, _backpackCapacity);
            _currentAmount = Mathf.Clamp(_currentAmount + delta, 0, _maxCapacity);
            //Debug.Log($"Pouring milk: {_currentAmount}/{_maxCapacity}");
        }
    }

    public void StartInteract(float pourRate)
    {
        Debug.Log($"Starting Bowl Interact");
        _interacting = true;
        _pourRate = pourRate;
    }

    public void StopInteract()
    {
        Debug.Log($"Ending Bowl Interact");
        _interacting = false;
    }
}
