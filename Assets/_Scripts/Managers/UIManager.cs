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
        [SerializeField] private Slider _playerFoodSlider;
        [SerializeField] private Slider _foodBowlSlider;

        // Dependencies
        private PlayerResources _pr;
        private MilkBowl _milkBowl;
        private FoodBowl _foodBowl;

        private void Start()
        {
            // Subscribe to UI Events
            InputManager.Instance.InputReader.Event_Pause   += HandlePause;
            InputManager.Instance.InputReader.Event_Unpause += HandleUnpause;

            ServiceLocator.Global.Get(out _pr)
                                 .Get(out _milkBowl)
                                 .Get(out _foodBowl);

            _milkBowl.CurrentMilk.AddListener(HandleMilkUpdate);
            _foodBowl.CurrentFood.AddListener(HandleFoodUpdate);
            _pr.CurrentMilk.AddListener(HandlePlayerMilkUpdate);
            _pr.CurrentFood.AddListener(HandlePlayerFoodUpdate);
        }

        // Event Handler Methods
        private void HandlePause() => _pauseMenu.SetActive(true);
        private void HandleUnpause() => _pauseMenu.SetActive(false);
        private void HandleMilkUpdate(float value)       => _milkBowlSlider.value = value / _milkBowl.MaxCapacity;
        private void HandleFoodUpdate(float value)       => _foodBowlSlider.value = value / _foodBowl.MaxCapacity;
        private void HandlePlayerMilkUpdate(float value) => _playerMilkSlider.value = value / 100f;
        private void HandlePlayerFoodUpdate(float value) => _playerFoodSlider.value = value / 100f;
    }
}
