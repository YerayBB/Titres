//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Input/Controls.inputactions
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

namespace Titres
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""PieceActions"",
            ""id"": ""c9c52495-4d22-437b-a204-e4accfe11d8b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""0ab05233-daa2-42b1-b50c-b90557f99ba5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""9a6998fe-66f9-448f-b26a-afe037d9cbd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""ea8f42c0-4677-40f9-af3e-aaf8503e5aa8"",
                    ""expectedControlType"": ""Integer"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a389f43a-2ee5-45f9-b1ec-401895342fbe"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7e28a6cc-7e57-49bc-8e56-a8825989cc85"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""68c050a9-6d27-47c9-83eb-3ca64f2b8eb8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5a4af385-0b39-4e02-9eb8-b18095f58d6e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e87e0ed0-a1df-4908-8524-20d36d2531b5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""de69a269-8f8d-4531-bf21-391fe7dfc270"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""33354130-6f0c-427e-8b4e-0cb03576e1ca"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cc7e2d6b-9e50-4319-9dc6-d88271e2769d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5dd049a6-4cde-4aca-8e64-3c5787a511d0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""345bb527-d1b9-441f-9bd0-de83c95da83a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3ed55fa0-f0f6-4449-be08-72150abcc163"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""GameOverActions"",
            ""id"": ""350e263d-e2e6-4f46-97a8-6b2febe80aa9"",
            ""actions"": [
                {
                    ""name"": ""Retry"",
                    ""type"": ""Button"",
                    ""id"": ""0be0e393-f896-48eb-8b75-4a75424347fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""b06ffa90-b66f-4935-94ed-bbe33e60f7a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fcf14e76-75c6-4133-9e6d-ef01e2f06637"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Retry"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7212292b-f4be-411f-86e2-a4b7fa46d8a4"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""7e42b166-72a7-42bd-8e50-1636993f410e"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""7d4c39af-8499-48da-b22d-b3871d7cc3b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9282536c-ff21-4453-ab3f-b6772642cae9"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PieceActions
            m_PieceActions = asset.FindActionMap("PieceActions", throwIfNotFound: true);
            m_PieceActions_Movement = m_PieceActions.FindAction("Movement", throwIfNotFound: true);
            m_PieceActions_Drop = m_PieceActions.FindAction("Drop", throwIfNotFound: true);
            m_PieceActions_Rotate = m_PieceActions.FindAction("Rotate", throwIfNotFound: true);
            // GameOverActions
            m_GameOverActions = asset.FindActionMap("GameOverActions", throwIfNotFound: true);
            m_GameOverActions_Retry = m_GameOverActions.FindAction("Retry", throwIfNotFound: true);
            m_GameOverActions_Quit = m_GameOverActions.FindAction("Quit", throwIfNotFound: true);
            // New action map
            m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
            m_Newactionmap_Newaction = m_Newactionmap.FindAction("New action", throwIfNotFound: true);
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

        // PieceActions
        private readonly InputActionMap m_PieceActions;
        private IPieceActionsActions m_PieceActionsActionsCallbackInterface;
        private readonly InputAction m_PieceActions_Movement;
        private readonly InputAction m_PieceActions_Drop;
        private readonly InputAction m_PieceActions_Rotate;
        public struct PieceActionsActions
        {
            private @Controls m_Wrapper;
            public PieceActionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_PieceActions_Movement;
            public InputAction @Drop => m_Wrapper.m_PieceActions_Drop;
            public InputAction @Rotate => m_Wrapper.m_PieceActions_Rotate;
            public InputActionMap Get() { return m_Wrapper.m_PieceActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PieceActionsActions set) { return set.Get(); }
            public void SetCallbacks(IPieceActionsActions instance)
            {
                if (m_Wrapper.m_PieceActionsActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnMovement;
                    @Drop.started -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnDrop;
                    @Drop.performed -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnDrop;
                    @Drop.canceled -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnDrop;
                    @Rotate.started -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnRotate;
                    @Rotate.performed -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnRotate;
                    @Rotate.canceled -= m_Wrapper.m_PieceActionsActionsCallbackInterface.OnRotate;
                }
                m_Wrapper.m_PieceActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Drop.started += instance.OnDrop;
                    @Drop.performed += instance.OnDrop;
                    @Drop.canceled += instance.OnDrop;
                    @Rotate.started += instance.OnRotate;
                    @Rotate.performed += instance.OnRotate;
                    @Rotate.canceled += instance.OnRotate;
                }
            }
        }
        public PieceActionsActions @PieceActions => new PieceActionsActions(this);

        // GameOverActions
        private readonly InputActionMap m_GameOverActions;
        private IGameOverActionsActions m_GameOverActionsActionsCallbackInterface;
        private readonly InputAction m_GameOverActions_Retry;
        private readonly InputAction m_GameOverActions_Quit;
        public struct GameOverActionsActions
        {
            private @Controls m_Wrapper;
            public GameOverActionsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Retry => m_Wrapper.m_GameOverActions_Retry;
            public InputAction @Quit => m_Wrapper.m_GameOverActions_Quit;
            public InputActionMap Get() { return m_Wrapper.m_GameOverActions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameOverActionsActions set) { return set.Get(); }
            public void SetCallbacks(IGameOverActionsActions instance)
            {
                if (m_Wrapper.m_GameOverActionsActionsCallbackInterface != null)
                {
                    @Retry.started -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnRetry;
                    @Retry.performed -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnRetry;
                    @Retry.canceled -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnRetry;
                    @Quit.started -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnQuit;
                    @Quit.performed -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnQuit;
                    @Quit.canceled -= m_Wrapper.m_GameOverActionsActionsCallbackInterface.OnQuit;
                }
                m_Wrapper.m_GameOverActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Retry.started += instance.OnRetry;
                    @Retry.performed += instance.OnRetry;
                    @Retry.canceled += instance.OnRetry;
                    @Quit.started += instance.OnQuit;
                    @Quit.performed += instance.OnQuit;
                    @Quit.canceled += instance.OnQuit;
                }
            }
        }
        public GameOverActionsActions @GameOverActions => new GameOverActionsActions(this);

        // New action map
        private readonly InputActionMap m_Newactionmap;
        private INewactionmapActions m_NewactionmapActionsCallbackInterface;
        private readonly InputAction m_Newactionmap_Newaction;
        public struct NewactionmapActions
        {
            private @Controls m_Wrapper;
            public NewactionmapActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
            public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
            public void SetCallbacks(INewactionmapActions instance)
            {
                if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
                {
                    @Newaction.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                    @Newaction.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                    @Newaction.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                }
                m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Newaction.started += instance.OnNewaction;
                    @Newaction.performed += instance.OnNewaction;
                    @Newaction.canceled += instance.OnNewaction;
                }
            }
        }
        public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
        public interface IPieceActionsActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnDrop(InputAction.CallbackContext context);
            void OnRotate(InputAction.CallbackContext context);
        }
        public interface IGameOverActionsActions
        {
            void OnRetry(InputAction.CallbackContext context);
            void OnQuit(InputAction.CallbackContext context);
        }
        public interface INewactionmapActions
        {
            void OnNewaction(InputAction.CallbackContext context);
        }
    }
}
