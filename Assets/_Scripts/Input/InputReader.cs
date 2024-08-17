using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReader")]
public class InputReader : ScriptableObject, InputMappings.IGameplayActions, InputMappings.IUIActions
{
    private InputMappings _inputMappings;

    // Actions
    public event Action<Vector2> Event_Move;
    public event Action Event_Jump;
    public event Action Event_JumpCancelled;
    public event Action Event_Sprint;
    public event Action Event_SprintCancelled;
    public event Action Event_Pause;
    public event Action Event_Unpause;

    private void OnEnable()
    {
        if (_inputMappings == null)
        {
            _inputMappings = new InputMappings();

            _inputMappings.Gameplay.SetCallbacks(this);
            _inputMappings.UI.SetCallbacks(this);

            SetGameplay();
        }
    }

    public void SetGameplay()
    {
        _inputMappings.Gameplay.Enable();
        _inputMappings.UI.Disable();
    }

    public void SetUI()
    {
        _inputMappings.Gameplay.Disable();
        _inputMappings.UI.Enable();
    }

    #region Gameplay

    public void OnMovement(InputAction.CallbackContext context) => Event_Move?.Invoke(context.ReadValue<Vector2>());

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.phase == InputActionPhase.Performed) Event_Jump?.Invoke();
        if (context.phase == InputActionPhase.Canceled) Event_JumpCancelled.Invoke();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) Event_Sprint?.Invoke();
        if (context.phase == InputActionPhase.Canceled) Event_SprintCancelled.Invoke();
    }

    #endregion Gameplay

    #region UI

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Event_Pause?.Invoke();
            SetUI();
        }
    }

    public void OnUnpause(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Event_Unpause?.Invoke();
            SetGameplay();
        }
    }

    #endregion UI
}
