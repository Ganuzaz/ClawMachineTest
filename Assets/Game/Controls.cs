// GENERATED AUTOMATICALLY FROM 'Assets/Game/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Claw"",
            ""id"": ""5bd10820-3845-4f4d-9164-e4b037de8e4c"",
            ""actions"": [
                {
                    ""name"": ""Descend"",
                    ""type"": ""Button"",
                    ""id"": ""e1af9367-dc31-418a-8793-fd412c924295"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c3d9252c-2f00-4337-9be7-28d0e8697db2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c40225b7-84fd-4c7f-a9c7-6768e6a322d0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Descend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24ba1abe-0fec-4a88-84e2-451e9244ac48"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Descend"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""772ec3bd-1a08-4f9f-8df0-18842c9cb360"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9ab7bf75-ec83-47bd-85f9-e122edf0400e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5ff372b9-91fb-4c54-b3af-d2542a7532da"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6c0447fc-f61e-425f-b74d-589827bdf6e5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e348c845-c181-4165-ae54-3d25d5762612"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""91c1599f-eb90-4527-8065-d52fee606d5d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e872e09c-d574-4637-aada-566fa04c30da"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b30d4a3d-a75c-495e-a923-6542f8408541"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9242658c-13bd-40b5-8865-5e789b4fa01c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""5a20e0e9-c547-46f8-a97c-00d88ea12cc5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0667efd9-5e17-49e3-bf53-d223d4636d2e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Claw
        m_Claw = asset.FindActionMap("Claw", throwIfNotFound: true);
        m_Claw_Descend = m_Claw.FindAction("Descend", throwIfNotFound: true);
        m_Claw_Move = m_Claw.FindAction("Move", throwIfNotFound: true);
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

    // Claw
    private readonly InputActionMap m_Claw;
    private IClawActions m_ClawActionsCallbackInterface;
    private readonly InputAction m_Claw_Descend;
    private readonly InputAction m_Claw_Move;
    public struct ClawActions
    {
        private @Controls m_Wrapper;
        public ClawActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Descend => m_Wrapper.m_Claw_Descend;
        public InputAction @Move => m_Wrapper.m_Claw_Move;
        public InputActionMap Get() { return m_Wrapper.m_Claw; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ClawActions set) { return set.Get(); }
        public void SetCallbacks(IClawActions instance)
        {
            if (m_Wrapper.m_ClawActionsCallbackInterface != null)
            {
                @Descend.started -= m_Wrapper.m_ClawActionsCallbackInterface.OnDescend;
                @Descend.performed -= m_Wrapper.m_ClawActionsCallbackInterface.OnDescend;
                @Descend.canceled -= m_Wrapper.m_ClawActionsCallbackInterface.OnDescend;
                @Move.started -= m_Wrapper.m_ClawActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ClawActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ClawActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_ClawActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Descend.started += instance.OnDescend;
                @Descend.performed += instance.OnDescend;
                @Descend.canceled += instance.OnDescend;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public ClawActions @Claw => new ClawActions(this);
    public interface IClawActions
    {
        void OnDescend(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
