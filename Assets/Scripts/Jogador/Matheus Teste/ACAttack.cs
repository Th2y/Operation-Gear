// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Jogador/Matheus Teste/ACAttack.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ACAttack : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ACAttack()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ACAttack"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""bed6a340-8e1d-49e9-a284-423e018d7396"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1da6556-359c-4863-b7ef-5a778bb6643f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d7f7d5bb-3664-483c-89c5-1a77b8e424ba"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Attack = m_Action.FindAction("Attack", throwIfNotFound: true);
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

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_Attack;
    public struct ActionActions
    {
        private @ACAttack m_Wrapper;
        public ActionActions(@ACAttack wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Action_Attack;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IActionActions
    {
        void OnAttack(InputAction.CallbackContext context);
    }
}
