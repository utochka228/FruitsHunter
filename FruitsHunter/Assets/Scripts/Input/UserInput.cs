using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Input
{
    public class UserInput : MonoBehaviour
    {
        public static Action<Vector2> OnScreenPressed;

        private Vector2 _screenPrimaryPos;

        private UserActions _userActions;
        private void Start()
        {
            _userActions = new UserActions();
            _userActions.Enable();
            _userActions.Character.PrimaryScreenPos.performed +=
                context => _screenPrimaryPos = context.ReadValue<Vector2>();
            _userActions.Character.PrimaryScreenPress.performed += OnScreenTapped;
        }

        private void OnScreenTapped(InputAction.CallbackContext context)
        {
            OnScreenPressed?.Invoke(_screenPrimaryPos);
        }
    }
}
