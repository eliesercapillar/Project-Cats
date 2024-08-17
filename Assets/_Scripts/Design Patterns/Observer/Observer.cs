using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

namespace DesignPatterns
{
    /// <summary>
    /// A generic observer implemented using Unity Events.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Observer<T>
    {
        [SerializeField] T _value;
        [SerializeField] UnityEvent<T> _onValueChanged;

        public T Value { get { return _value; } set { Set(value); }}
        public static implicit operator T(Observer<T> observer) => observer._value; // Useful, but does have overhead so use sparingly.

        public Observer(T value, UnityAction<T> callback = null)
        {
            _value = value;
            _onValueChanged = new UnityEvent<T>();
            if (callback!= null) _onValueChanged.AddListener(callback);
        }

        public void Set(T value)
        {
            if (Equals(_value, value)) return;
            _value = value;
            Invoke();
        }

        public void Invoke()
        {
            Debug.Log($"Invoking {_onValueChanged.GetPersistentEventCount()} listeners");
            _onValueChanged.Invoke(_value);
        }

        public void AddListener(UnityAction<T> callback)
        {
            if (callback == null) return;
            if (_onValueChanged == null) _onValueChanged = new UnityEvent<T>();
            _onValueChanged.AddListener(callback);
        }

        public void RemoveListener(UnityAction<T> callback)
        {
            if (callback == null) return;
            if (_onValueChanged == null) _onValueChanged = new UnityEvent<T>();
            _onValueChanged.RemoveListener(callback);
        }

        public void RemoveAllListeners()
        {
            if (_onValueChanged == null) return;
            _onValueChanged.RemoveAllListeners();
        }

        public void Dispose()
        {
            RemoveAllListeners();
            _onValueChanged = null;
            _value = default;
        }
    }
}
