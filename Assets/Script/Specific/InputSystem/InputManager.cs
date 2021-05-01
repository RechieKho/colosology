using UnityEngine;
using UnityEngine.InputSystem;
using General.Other;

namespace Specific.InputSystem
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {
        private InputMaster _inputMaster;
        private E_Input _eInput;
        public static InputMaster MainInput
        {
            get { return Instance._inputMaster; }
        }
        public static E_Input ExtraInput
        {
            get { return Instance._eInput; }
        }

        private void Awake()
        {
            _inputMaster = new InputMaster();
            _eInput = new E_Input();
        }

        private void OnEnable()
        {
            _inputMaster.Enable();
        }

        private void OnDisable()
        {
            _inputMaster.Disable();
        }

        private void Update()
        {
            _eInput.Check();
        }

        #region subclass
        public class E_Input
        {
            public delegate void MouseEvent();
            public MouseEvent OnLeftMouseDown;
            public MouseEvent OnLeftMouseUp;

            public void Check()
            {
                if (Mouse.current.leftButton.wasPressedThisFrame) OnLeftMouseDown?.Invoke();
                if (Mouse.current.leftButton.wasReleasedThisFrame) OnLeftMouseUp?.Invoke();
            }
        }
        #endregion
    }


}



