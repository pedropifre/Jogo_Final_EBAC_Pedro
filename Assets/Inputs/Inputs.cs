// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Inputs.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""ce12bad9-9c33-4461-be57-92cf930fa62f"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""3d0cc15e-a5a6-4171-ae0e-8f2916ffc741"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeaponSlot_1"",
                    ""type"": ""Button"",
                    ""id"": ""cc082257-e91e-461d-b06c-e1665e63a2ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeaponSlot_2"",
                    ""type"": ""Button"",
                    ""id"": ""8256c23a-f1a1-4fce-9091-9248bb0ac692"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""436e43c2-63b2-4745-bb65-69781e17925b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""722b17ea-00c5-4b41-b5c1-ef655f3ef4c4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponSlot_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6499a98-fbb1-46c8-96ec-681aac30ebf9"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeWeaponSlot_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Shoot = m_Gameplay.FindAction("Shoot", throwIfNotFound: true);
        m_Gameplay_ChangeWeaponSlot_1 = m_Gameplay.FindAction("ChangeWeaponSlot_1", throwIfNotFound: true);
        m_Gameplay_ChangeWeaponSlot_2 = m_Gameplay.FindAction("ChangeWeaponSlot_2", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Shoot;
    private readonly InputAction m_Gameplay_ChangeWeaponSlot_1;
    private readonly InputAction m_Gameplay_ChangeWeaponSlot_2;
    public struct GameplayActions
    {
        private @Inputs m_Wrapper;
        public GameplayActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Gameplay_Shoot;
        public InputAction @ChangeWeaponSlot_1 => m_Wrapper.m_Gameplay_ChangeWeaponSlot_1;
        public InputAction @ChangeWeaponSlot_2 => m_Wrapper.m_Gameplay_ChangeWeaponSlot_2;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnShoot;
                @ChangeWeaponSlot_1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_2;
                @ChangeWeaponSlot_2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_2;
                @ChangeWeaponSlot_2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeWeaponSlot_2;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ChangeWeaponSlot_1.started += instance.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_1.performed += instance.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_1.canceled += instance.OnChangeWeaponSlot_1;
                @ChangeWeaponSlot_2.started += instance.OnChangeWeaponSlot_2;
                @ChangeWeaponSlot_2.performed += instance.OnChangeWeaponSlot_2;
                @ChangeWeaponSlot_2.canceled += instance.OnChangeWeaponSlot_2;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnChangeWeaponSlot_1(InputAction.CallbackContext context);
        void OnChangeWeaponSlot_2(InputAction.CallbackContext context);
    }
}
