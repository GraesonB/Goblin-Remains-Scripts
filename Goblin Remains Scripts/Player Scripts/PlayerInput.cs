// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Player Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Playing"",
            ""id"": ""506baf38-b80f-4b35-ae87-1718cee06b20"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""81871a7b-78c1-490e-abce-092153b4a456"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BasicAttack"",
                    ""type"": ""Button"",
                    ""id"": ""28e8c03e-c195-49ae-b39b-c5737f0b8bce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""29bf7a56-0969-463f-9a97-6badd7d147aa"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug1"",
                    ""type"": ""Button"",
                    ""id"": ""cc671426-0e84-4963-876f-cde443b45758"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug2"",
                    ""type"": ""Button"",
                    ""id"": ""17b9fb4a-0623-48d6-990c-acc0e12c5da4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BombSpecial"",
                    ""type"": ""Button"",
                    ""id"": ""b39ca73d-74e2-4f16-a11d-451c9c2ac15d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""39f205b8-2cb5-46b4-b516-19bc90ba9b51"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BasicAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""f1f7f008-1fb5-42c3-9eeb-7d97a962295b"",
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
                    ""id"": ""c05aa7f4-2090-4dd3-8ffe-79425962ba54"",
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
                    ""id"": ""6f965de7-6527-4544-81e5-580bf731058a"",
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
                    ""id"": ""5c12df1e-41aa-4b74-b070-4d85aa44ebf7"",
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
                    ""id"": ""89215fc6-8ee0-4981-a10c-2a58f38ee5bc"",
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
                    ""id"": ""b224e56e-7235-4b92-bbe3-42cf9648e1d1"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b649e0d7-f9d0-4cf8-9476-d0c038636177"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee31a24d-04d1-4b3a-be8f-37597249ba04"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BombSpecial"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Playing
        m_Playing = asset.FindActionMap("Playing", throwIfNotFound: true);
        m_Playing_Move = m_Playing.FindAction("Move", throwIfNotFound: true);
        m_Playing_BasicAttack = m_Playing.FindAction("BasicAttack", throwIfNotFound: true);
        m_Playing_Camera = m_Playing.FindAction("Camera", throwIfNotFound: true);
        m_Playing_Debug1 = m_Playing.FindAction("Debug1", throwIfNotFound: true);
        m_Playing_Debug2 = m_Playing.FindAction("Debug2", throwIfNotFound: true);
        m_Playing_BombSpecial = m_Playing.FindAction("BombSpecial", throwIfNotFound: true);
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

    // Playing
    private readonly InputActionMap m_Playing;
    private IPlayingActions m_PlayingActionsCallbackInterface;
    private readonly InputAction m_Playing_Move;
    private readonly InputAction m_Playing_BasicAttack;
    private readonly InputAction m_Playing_Camera;
    private readonly InputAction m_Playing_Debug1;
    private readonly InputAction m_Playing_Debug2;
    private readonly InputAction m_Playing_BombSpecial;
    public struct PlayingActions
    {
        private @PlayerInput m_Wrapper;
        public PlayingActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Playing_Move;
        public InputAction @BasicAttack => m_Wrapper.m_Playing_BasicAttack;
        public InputAction @Camera => m_Wrapper.m_Playing_Camera;
        public InputAction @Debug1 => m_Wrapper.m_Playing_Debug1;
        public InputAction @Debug2 => m_Wrapper.m_Playing_Debug2;
        public InputAction @BombSpecial => m_Wrapper.m_Playing_BombSpecial;
        public InputActionMap Get() { return m_Wrapper.m_Playing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayingActions set) { return set.Get(); }
        public void SetCallbacks(IPlayingActions instance)
        {
            if (m_Wrapper.m_PlayingActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnMove;
                @BasicAttack.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBasicAttack;
                @BasicAttack.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBasicAttack;
                @Camera.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnCamera;
                @Debug1.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug1;
                @Debug1.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug1;
                @Debug1.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug1;
                @Debug2.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug2;
                @Debug2.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug2;
                @Debug2.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnDebug2;
                @BombSpecial.started -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBombSpecial;
                @BombSpecial.performed -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBombSpecial;
                @BombSpecial.canceled -= m_Wrapper.m_PlayingActionsCallbackInterface.OnBombSpecial;
            }
            m_Wrapper.m_PlayingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @BasicAttack.started += instance.OnBasicAttack;
                @BasicAttack.performed += instance.OnBasicAttack;
                @BasicAttack.canceled += instance.OnBasicAttack;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Debug1.started += instance.OnDebug1;
                @Debug1.performed += instance.OnDebug1;
                @Debug1.canceled += instance.OnDebug1;
                @Debug2.started += instance.OnDebug2;
                @Debug2.performed += instance.OnDebug2;
                @Debug2.canceled += instance.OnDebug2;
                @BombSpecial.started += instance.OnBombSpecial;
                @BombSpecial.performed += instance.OnBombSpecial;
                @BombSpecial.canceled += instance.OnBombSpecial;
            }
        }
    }
    public PlayingActions @Playing => new PlayingActions(this);
    public interface IPlayingActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnBasicAttack(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnDebug1(InputAction.CallbackContext context);
        void OnDebug2(InputAction.CallbackContext context);
        void OnBombSpecial(InputAction.CallbackContext context);
    }
}
