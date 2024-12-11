using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using Player;
using System;

public class MilkSource : MonoBehaviour
{
    private PlayerResources _currentPlayer = null;
    private bool _interacting = false;
    private float _fillRate = 0f;

    private void Update()
    {
        if (_interacting && _currentPlayer.CurrentMilk < _currentPlayer.MaxMilkCapacity)
        {
            float delta = _fillRate * Time.deltaTime;
            _currentPlayer.TryFillMilk(delta);
        }
    }

    public void StartInteract(GameObject player, float fillRate)
    {
        Debug.Log($"Starting Source Interact");

        _currentPlayer = player.GetComponent<PlayerResources>();
        if (_currentPlayer == null) throw new ArgumentNullException();

        _interacting = true;
        _fillRate = fillRate;
    }

    public void StopInteract()
    {
        Debug.Log($"Ending Source Interact");
        _currentPlayer = default;
        _interacting = default;
        _fillRate = default;
    }

}
