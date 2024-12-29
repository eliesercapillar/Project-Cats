using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using UnityEditor;

namespace Player
{
    public class PlayerAbilities : MonoBehaviour
    {
        [Header("Interaction Stategies")]
        [SerializeField] private InteractionStrategy[] _interactions;
        private int _currentStrategyEquippedIndex = 0;
        private InteractionStrategy _currentStrategy = null;

        [Header("Properties")]
        [SerializeField] private float _maxInteractRange = 3f;
        private GameObject _currentTarget; // The target the player is currently trying to interact with.

        // Dependencies
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }
        
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
            UpdateCurrentTarget();
            if (_currentTarget != null) _currentStrategy.InteractStarted(gameObject, _currentTarget);
            //if (_currentTarget != null) _interactions[_currentStrategyEquippedIndex].InteractStarted(gameObject, _currentTarget);
        }

        private void HandleInteract()
        {
            if (_currentTarget != null) _currentStrategy.Interact(gameObject, _currentTarget);
            //if (_currentTarget != null) _interactions[_currentStrategyEquippedIndex].Interact(gameObject, _currentTarget);
        }

        private void HandleInteractCanceled()
        {
            if (_currentTarget != null) _currentStrategy.InteractCancelled(gameObject, _currentTarget);
            //if (_currentTarget != null) _interactions[_currentStrategyEquippedIndex].InteractCancelled(gameObject, _currentTarget);
            ResetCurrentTarget();
        }

        private void HandlePositiveSwitch() => _currentStrategyEquippedIndex = ++_currentStrategyEquippedIndex % _interactions.Length;
        private void HandleNegativeSwitch() => _currentStrategyEquippedIndex = (--_currentStrategyEquippedIndex + _interactions.Length) % _interactions.Length;
    
        private void UpdateCurrentTarget()
        {
            ResetCurrentTarget();

            Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, _maxInteractRange);

            foreach (var hit in hits)
            {
                string tag = hit.collider.tag;

                switch (tag)
                {
                    case "Interactable":
                        _currentTarget = hit.collider.gameObject;
                        break;
                    case "Tool":
                        Debug.Log($"Retrieving Strategy for the Tool: {hit.collider.gameObject.name}");
                        _currentStrategy = hit.collider.GetComponent<ITool>().GetStrategy();
                        break;  
                    default:
                        Debug.Log("Not looking at a valid target.");
                        break;
                }
            }
        }

        private void ResetCurrentTarget() => _currentTarget = null;
    }
}
