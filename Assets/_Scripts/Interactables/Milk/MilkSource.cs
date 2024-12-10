using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class MilkSource : MonoBehaviour
{
    [SerializeField] private float _backpackCapacity = 100f;
    private float _currentBackpack = 0f;

    private bool _interacting = false;
    private float _fillRate;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_interacting)
        {
            float delta = _fillRate * Time.deltaTime;
            _currentBackpack = Mathf.Clamp(_currentBackpack + delta, 0, _backpackCapacity);
            //Debug.Log($"Filling container: {_currentBackpack}/{_backpackCapacity}");
        }
    }

    public void StartInteract(float fillRate)
    {
        Debug.Log($"Starting Source Interact");
        _interacting = true;
        _fillRate = fillRate;
    }

    public void StopInteract()
    {
        Debug.Log($"Ending Source Interact");
        _interacting = false;
    }

}
