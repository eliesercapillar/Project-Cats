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
        [SerializeField] private Slider _playerMilkSlider;
        [SerializeField] private Slider _milkBowlSlider;

        // Dependencies
        private PlayerResources _pr;
        private MilkBowl _milkBowl;

        private void Start()
        {
            // Subscribe to UI Events
            InputManager.Instance.InputReader.Event_Pause   += HandlePause;
            InputManager.Instance.InputReader.Event_Unpause += HandleUnpause;

            ServiceLocator.Global.Get(out _pr)
                                 .Get(out _milkBowl);

            _milkBowl.CurrentMilk.AddListener(HandleMilkUpdate);
            _pr.CurrentMilk.AddListener(HandlePlayerMilkUpdate);
        }

        // Event Handler Methods
        private void HandlePause() => _pauseMenu.SetActive(true);
        private void HandleUnpause() => _pauseMenu.SetActive(false);
        private void HandleMilkUpdate(float value)       => _milkBowlSlider.value = value / _milkBowl.MaxCapacity;
        private void HandlePlayerMilkUpdate(float value) => _playerMilkSlider.value = value / 100f;
    }
}
