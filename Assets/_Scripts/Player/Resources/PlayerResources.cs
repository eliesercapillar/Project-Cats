using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class PlayerResources : Singleton<PlayerResources>
{
    [Header("Properties")]
    [SerializeField] private float _maxMilkCapacity = 100f;

    // Resources
    private Observer<float> _currentMilk = new Observer<float>(0f);

    public float MaxMilkCapacity           { get {return _maxMilkCapacity;} }
    public Observer<float> CurrentMilk     { get {return _currentMilk;} }

    public bool TryPourMilk(float amount)
    {
        Debug.Log("Trying to pour milk...");
        if (_currentMilk <= 0) return false;

        _currentMilk.Value = Mathf.Clamp(_currentMilk - amount, 0, _maxMilkCapacity);
        return true;
    }

    public bool TryFillMilk(float amount)
    {
        Debug.Log("Trying to fill milk...");
        if (_currentMilk > _maxMilkCapacity) return false;

        _currentMilk.Value = Mathf.Clamp(_currentMilk + amount, 0, _maxMilkCapacity);
        return true;
    }
}
