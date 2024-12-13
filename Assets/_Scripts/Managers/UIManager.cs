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
        [SerializeField] private Slider _playerMilk;
        [SerializeField] private Slider _milkBowl;

        private void Start()
        {
            // Subscribe to UI Events
            InputManager.Instance.InputReader.Event_Pause   += HandlePause;
            InputManager.Instance.InputReader.Event_Unpause += HandleUnpause;

            MilkBowl.Instance.CurrentMilk.AddListener(HandleMilkUpdate);
            PlayerResources.Instance.CurrentMilk.AddListener(HandlePlayerMilkUpdate);
        }

        // Event Handler Methods
        private void HandlePause() => _pauseMenu.SetActive(true);
        private void HandleUnpause() => _pauseMenu.SetActive(false);
        private void HandleMilkUpdate(float value)       => _milkBowl.value = value / MilkBowl.Instance.MaxCapacity;
        private void HandlePlayerMilkUpdate(float value) => _playerMilk.value = value / 100f;
    }
}
