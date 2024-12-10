using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player
{
    public class PlayerAbilities : MonoBehaviour
    {
        [Header("Interaction Stategies")]
        [SerializeField] private InteractionStrategy[] _interactions;
        private int _currentStrategyEquippedIndex = 0;
        
        private void Start()
        {
            // Subscribe to Gameplay Events
            InputManager.Instance.InputReader.Event_InteractStarted   += HandleInteractStarted;
            InputManager.Instance.InputReader.Event_Interact          += HandleInteract;
            InputManager.Instance.InputReader.Event_InteractCancelled += HandleInteractCanceled;

            InputManager.Instance.InputReader.Event_SwitchPositive += HandlePositiveSwitch;
            InputManager.Instance.InputReader.Event_SwitchNegative += HandleNegativeSwitch;
        }

        private void HandleInteractStarted()
        {
            _interactions[_currentStrategyEquippedIndex].InteractStarted();
        }

        private void HandleInteract()
        {
            _interactions[_currentStrategyEquippedIndex].Interact();
        }

        private void HandleInteractCanceled()
        {
            _interactions[_currentStrategyEquippedIndex].InteractCancelled();
        }

        private void HandlePositiveSwitch() => _currentStrategyEquippedIndex = ++_currentStrategyEquippedIndex % _interactions.Length;
        private void HandleNegativeSwitch() => _currentStrategyEquippedIndex = (--_currentStrategyEquippedIndex + _interactions.Length) % _interactions.Length;
    }
}
