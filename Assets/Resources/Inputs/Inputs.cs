// GENERATED AUTOMATICALLY FROM 'Assets/Resources/Inputs/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""Ship"",
            ""id"": ""887034ba-2baf-4ac8-b170-91e6f2456953"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""5a66d1df-023b-4041-aaa3-9dd0819b11ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""FirePrimaryWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""1cc43802-f493-47dc-8a12-a0a2d9b59d56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FireSecondWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""ce80e7d5-2f3f-42f2-8963-64b76a526ea9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""4932fd2e-2703-4615-a5ca-5d7a27ccbc85"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5be3f410-9e67-4b54-9394-b4435c362f0b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""349728d2-9342-49d4-9ef8-676d2bb9e5cb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12c938ef-f2bb-413d-afe0-9796ab417e4d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1158421c-69fc-44d0-87f9-5cac42267c0f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirePrimaryWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cebc33fd-8be7-4f04-b5a5-e44f602cc0fb"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireSecondWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f268d7f-ae57-4bc4-ab95-db2f0efe10a4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""236f7ed0-24a5-4722-a95d-0fc50c23921b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5347a3c7-8102-48f7-879b-91b7d13f9533"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1ae1f18-8755-4082-8636-fab3a8d6b432"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""87bf5244-7f2a-41b4-bc17-9d6f735b5ca8"",
            ""actions"": [
                {
                    ""name"": ""AnyKeyPressed"",
                    ""type"": ""Button"",
                    ""id"": ""0ecc9c56-dfd6-4469-b970-9111a5859f24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""09ff4e9f-ed57-46a1-abf3-90ed1410c591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58933d23-66dd-415d-9073-751831963933"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AnyKeyPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""338a5e0b-daf4-4425-925d-103bed211314"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ship
        m_Ship = asset.FindActionMap("Ship", throwIfNotFound: true);
        m_Ship_Forward = m_Ship.FindAction("Forward", throwIfNotFound: true);
        m_Ship_FirePrimaryWeapon = m_Ship.FindAction("FirePrimaryWeapon", throwIfNotFound: true);
        m_Ship_FireSecondWeapon = m_Ship.FindAction("FireSecondWeapon", throwIfNotFound: true);
        m_Ship_RotateRight = m_Ship.FindAction("RotateRight", throwIfNotFound: true);
        m_Ship_RotateLeft = m_Ship.FindAction("RotateLeft", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_AnyKeyPressed = m_MainMenu.FindAction("AnyKeyPressed", throwIfNotFound: true);
        m_MainMenu_Start = m_MainMenu.FindAction("Start", throwIfNotFound: true);
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

    // Ship
    private readonly InputActionMap m_Ship;
    private IShipActions m_ShipActionsCallbackInterface;
    private readonly InputAction m_Ship_Forward;
    private readonly InputAction m_Ship_FirePrimaryWeapon;
    private readonly InputAction m_Ship_FireSecondWeapon;
    private readonly InputAction m_Ship_RotateRight;
    private readonly InputAction m_Ship_RotateLeft;
    public struct ShipActions
    {
        private @Inputs m_Wrapper;
        public ShipActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Ship_Forward;
        public InputAction @FirePrimaryWeapon => m_Wrapper.m_Ship_FirePrimaryWeapon;
        public InputAction @FireSecondWeapon => m_Wrapper.m_Ship_FireSecondWeapon;
        public InputAction @RotateRight => m_Wrapper.m_Ship_RotateRight;
        public InputAction @RotateLeft => m_Wrapper.m_Ship_RotateLeft;
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
        public void SetCallbacks(IShipActions instance)
        {
            if (m_Wrapper.m_ShipActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnForward;
                @FirePrimaryWeapon.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirePrimaryWeapon;
                @FirePrimaryWeapon.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirePrimaryWeapon;
                @FirePrimaryWeapon.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFirePrimaryWeapon;
                @FireSecondWeapon.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireSecondWeapon;
                @FireSecondWeapon.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireSecondWeapon;
                @FireSecondWeapon.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnFireSecondWeapon;
                @RotateRight.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateRight;
                @RotateLeft.started -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_ShipActionsCallbackInterface.OnRotateLeft;
            }
            m_Wrapper.m_ShipActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @FirePrimaryWeapon.started += instance.OnFirePrimaryWeapon;
                @FirePrimaryWeapon.performed += instance.OnFirePrimaryWeapon;
                @FirePrimaryWeapon.canceled += instance.OnFirePrimaryWeapon;
                @FireSecondWeapon.started += instance.OnFireSecondWeapon;
                @FireSecondWeapon.performed += instance.OnFireSecondWeapon;
                @FireSecondWeapon.canceled += instance.OnFireSecondWeapon;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
            }
        }
    }
    public ShipActions @Ship => new ShipActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_AnyKeyPressed;
    private readonly InputAction m_MainMenu_Start;
    public struct MainMenuActions
    {
        private @Inputs m_Wrapper;
        public MainMenuActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @AnyKeyPressed => m_Wrapper.m_MainMenu_AnyKeyPressed;
        public InputAction @Start => m_Wrapper.m_MainMenu_Start;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @AnyKeyPressed.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKeyPressed;
                @AnyKeyPressed.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKeyPressed;
                @AnyKeyPressed.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAnyKeyPressed;
                @Start.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @AnyKeyPressed.started += instance.OnAnyKeyPressed;
                @AnyKeyPressed.performed += instance.OnAnyKeyPressed;
                @AnyKeyPressed.canceled += instance.OnAnyKeyPressed;
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);
    public interface IShipActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnFirePrimaryWeapon(InputAction.CallbackContext context);
        void OnFireSecondWeapon(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnAnyKeyPressed(InputAction.CallbackContext context);
        void OnStart(InputAction.CallbackContext context);
    }
}
