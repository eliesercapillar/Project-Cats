using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;

public class InputManager : PersistentSingleton<InputManager>
{
    [Header("Scriptable Object Dependencies")]
    [SerializeField] private InputReader _inputReader;

    // Getters
    public InputReader InputReader { get { return _inputReader; } }

    protected override void Awake()
    {
        base.Awake();
        if (InputReader == null) _inputReader = new InputReader();
    }
}
