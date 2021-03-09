// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Jogador/PlayerMovimento.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMovimento : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMovimento()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMovimento"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""98b20a34-1425-4f70-97ae-ebf38ae1f920"",
            ""actions"": [
                {
                    ""name"": ""Mover"",
                    ""type"": ""Button"",
                    ""id"": ""63389e1a-5971-41e0-a98c-fcb713b873db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7cec59ce-00fa-47f3-8000-206aa051a141"",
                    ""path"": ""<AndroidJoystick>/stick/left"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca70c0c8-e01e-4c15-97b9-7e3aee827a6b"",
                    ""path"": ""<AndroidJoystick>/stick/right"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0f23a09-d687-4b9c-a7a4-b272cb3f0b2a"",
                    ""path"": ""<AndroidJoystick>/stick/up"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7293f7a1-5ab5-492b-ad50-c4c259681fdb"",
                    ""path"": ""<AndroidJoystick>/stick/down"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mover"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Mover = m_Touch.FindAction("Mover", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Mover;
    public struct TouchActions
    {
        private @PlayerMovimento m_Wrapper;
        public TouchActions(@PlayerMovimento wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mover => m_Wrapper.m_Touch_Mover;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Mover.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnMover;
                @Mover.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnMover;
                @Mover.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnMover;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mover.started += instance.OnMover;
                @Mover.performed += instance.OnMover;
                @Mover.canceled += instance.OnMover;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnMover(InputAction.CallbackContext context);
    }
}
