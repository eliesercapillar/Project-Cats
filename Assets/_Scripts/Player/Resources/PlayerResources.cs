using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _maxMilkCapacity = 100f;

    [Header("Resources")]
    [SerializeField] private float _currentMilk = 0f;

    public float MaxMilkCapacity { get {return _maxMilkCapacity;} }
    public float CurrentMilk     { get {return _currentMilk;} set {_currentMilk = value;} }

    public bool TryPourMilk(float amount)
    {
        Debug.Log("Trying to pour milk...");
        if (_currentMilk <= 0) return false;

        _currentMilk = Mathf.Clamp(_currentMilk - amount, 0, _maxMilkCapacity);
        return true;
    }

    public bool TryFillMilk(float amount)
    {
        Debug.Log("Trying to fill milk...");
        if (_currentMilk > _maxMilkCapacity) return false;

        _currentMilk = Mathf.Clamp(_currentMilk + amount, 0, _maxMilkCapacity);
        return true;
    }
}
