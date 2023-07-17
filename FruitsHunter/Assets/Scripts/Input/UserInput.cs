using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Input
{
    public class UserInput : MonoBehaviour
    {
        public static Action<Vector2> OnScreenPressed;

        private UserActions _userActions;
        private void Start()
        {
            _userActions = new UserActions();
            _userActions.Enable();
            _userActions.Character.PrimaryScreenPress.performed += OnScreenTapped;
        }

        private void OnScreenTapped(InputAction.CallbackContext context)
        {
            var screenPrimaryPos = _userActions.Character.PrimaryScreenPos.ReadValue<Vector2>();
            OnScreenPressed?.Invoke(screenPrimaryPos);
        }
    }
}
