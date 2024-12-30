using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private GameObject _pauseMenu;

        private void Start()
        {
            // Subscribe to UI Events
            InputManager.Instance.InputReader.Event_Pause   += HandlePause;
            InputManager.Instance.InputReader.Event_Unpause += HandleUnpause;
        }

        // Event Handler Methods
        private void HandlePause() => _pauseMenu.SetActive(true);
        private void HandleUnpause() => _pauseMenu.SetActive(false);
    }
}
