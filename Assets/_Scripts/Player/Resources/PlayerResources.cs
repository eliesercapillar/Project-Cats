using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class PlayerResources : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float _maxMilkCapacity = 100f;
    [SerializeField] private float _maxFoodCapacity = 100f;

    // Resources
    private Observer<float> _currentMilk = new Observer<float>(0f);
    private Observer<float> _currentFood = new Observer<float>(0f);

    public float MaxMilkCapacity           { get {return _maxMilkCapacity;} }
    public Observer<float> CurrentMilk     { get {return _currentMilk;} }
    public float MaxFoodCapacity           { get {return _maxFoodCapacity;} }
    public Observer<float> CurrentFood     { get {return _currentFood;} }

    private void Awake()
    {
        ServiceLocator.Global.Register(this);
    }

    public bool TryPourFood(float amount)
    {
        Debug.Log("Trying to pour milk...");
        if (_currentFood <= 0) return false;

        _currentFood.Value = Mathf.Clamp(_currentFood - amount, 0, _maxFoodCapacity);
        return true;
    }

    public bool TryFillFood(float amount)
    {
        Debug.Log("Trying to fill milk...");
        if (_currentFood > _maxFoodCapacity) return false;

        _currentFood.Value = Mathf.Clamp(_currentFood + amount, 0, _maxFoodCapacity);
        return true;
    }

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
