//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/Input/UserActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @UserActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserActions"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""1cbc1bb6-53c1-4308-841c-a673227993f3"",
            ""actions"": [
                {
                    ""name"": ""PrimaryScreenPress"",
                    ""type"": ""Button"",
                    ""id"": ""9e6b4663-2cdc-41a3-aba0-bb4c0c51e790"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryScreenPos"",
                    ""type"": ""Value"",
                    ""id"": ""556a7f23-7a1f-45fb-b151-2fa2fe805f1a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b055c5bb-e3c8-4064-8873-4366d82ee0e7"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryScreenPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d99cbb9b-c805-42f4-a3c5-17b91d82ecc1"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryScreenPos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_PrimaryScreenPress = m_Character.FindAction("PrimaryScreenPress", throwIfNotFound: true);
        m_Character_PrimaryScreenPos = m_Character.FindAction("PrimaryScreenPos", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Character
    private readonly InputActionMap m_Character;
    private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();
    private readonly InputAction m_Character_PrimaryScreenPress;
    private readonly InputAction m_Character_PrimaryScreenPos;
    public struct CharacterActions
    {
        private @UserActions m_Wrapper;
        public CharacterActions(@UserActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryScreenPress => m_Wrapper.m_Character_PrimaryScreenPress;
        public InputAction @PrimaryScreenPos => m_Wrapper.m_Character_PrimaryScreenPos;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
            @PrimaryScreenPress.started += instance.OnPrimaryScreenPress;
            @PrimaryScreenPress.performed += instance.OnPrimaryScreenPress;
            @PrimaryScreenPress.canceled += instance.OnPrimaryScreenPress;
            @PrimaryScreenPos.started += instance.OnPrimaryScreenPos;
            @PrimaryScreenPos.performed += instance.OnPrimaryScreenPos;
            @PrimaryScreenPos.canceled += instance.OnPrimaryScreenPos;
        }

        private void UnregisterCallbacks(ICharacterActions instance)
        {
            @PrimaryScreenPress.started -= instance.OnPrimaryScreenPress;
            @PrimaryScreenPress.performed -= instance.OnPrimaryScreenPress;
            @PrimaryScreenPress.canceled -= instance.OnPrimaryScreenPress;
            @PrimaryScreenPos.started -= instance.OnPrimaryScreenPos;
            @PrimaryScreenPos.performed -= instance.OnPrimaryScreenPos;
            @PrimaryScreenPos.canceled -= instance.OnPrimaryScreenPos;
        }

        public void RemoveCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnPrimaryScreenPress(InputAction.CallbackContext context);
        void OnPrimaryScreenPos(InputAction.CallbackContext context);
    }
}
