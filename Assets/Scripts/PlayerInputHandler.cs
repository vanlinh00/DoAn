using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Tooltip("Sensitivity multiplier for moving the camera around")]
        public float LookSensitivity = 1f;

        [Tooltip("Additional sensitivity multiplier for WebGL")]
        public float WebglLookSensitivityMultiplier = 0.25f;

        [Tooltip("Limit to consider an input when using a trigger on a controller")]
        public float TriggerAxisThreshold = 0.4f;

        [Tooltip("Used to flip the vertical input axis")]
        public bool InvertYAxis = false;

        [Tooltip("Used to flip the horizontal input axis")]
        public bool InvertXAxis = false;

        //GameFlowManager m_GameFlowManager;
        PlayerCharacterController m_PlayerCharacterController;
        //  bool m_FireInputWasHeld;

        void Start()
        {
            m_PlayerCharacterController = GetComponent<PlayerCharacterController>();
            //   DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterController, PlayerInputHandler>(m_PlayerCharacterController, this, gameObject);
            //  m_GameFlowManager = FindObjectOfType<GameFlowManager>();
            //    DebugUtility.HandleErrorIfNullFindObject<GameFlowManager, PlayerInputHandler>(m_GameFlowManager, this);

            DisableCursor();
        }

        public void DisableCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }    
        void LateUpdate()
        {
          //  m_FireInputWasHeld = GetFireInputHeld();
        }

        public bool CanProcessInput()
        {
            return Cursor.lockState == CursorLockMode.Locked;// && !m_GameFlowManager.GameIsEnding;
        }

        public float GetLookInputsHorizontal()
        {
            return GetMouseOrStickLookAxis(GameConstants.k_MouseAxisNameHorizontal,
                GameConstants.k_AxisNameJoystickLookHorizontal);
        }

        public float GetLookInputsVertical()
        {
            return GetMouseOrStickLookAxis(GameConstants.k_MouseAxisNameVertical,
                GameConstants.k_AxisNameJoystickLookVertical);
        }
        public bool GetSprintInputHeld()
        {
            if (CanProcessInput())
            {
                return Input.GetButton(GameConstants.k_ButtonNameSprint);
            }

            return false;
        }

        public Vector3 GetMoveInput()
        {
            if (CanProcessInput())
            {
                Vector3 move = new Vector3(Input.GetAxisRaw(GameConstants.k_AxisNameHorizontal), 0f,
                    Input.GetAxisRaw(GameConstants.k_AxisNameVertical));

                // constrain move input to a maximum magnitude of 1, otherwise diagonal movement might exceed the max move speed defined
                move = Vector3.ClampMagnitude(move, 1);

                return move;
            }

            return Vector3.zero;
        }
        float GetMouseOrStickLookAxis(string mouseInputName, string stickInputName)
        {
            if (CanProcessInput())
            {
                // Check if this look input is coming from the mouse
                bool isGamepad = Input.GetAxis(stickInputName) != 0f;
                float i = isGamepad ? Input.GetAxis(stickInputName) : Input.GetAxisRaw(mouseInputName);

                // handle inverting vertical input
                if (InvertYAxis)
                    i *= -1f;

                // apply sensitivity multiplier
                i *= LookSensitivity;

                if (isGamepad)
                {
                    // since mouse input is already deltaTime-dependant, only scale input with frame time if it's coming from sticks
                    i *= Time.deltaTime;
                }
                else
                {
                    // reduce mouse input amount to be equivalent to stick movement
                    i *= 0.01f;
#if UNITY_WEBGL
                    // Mouse tends to be even more sensitive in WebGL due to mouse acceleration, so reduce it even more
                    i *= WebglLookSensitivityMultiplier;
#endif
                }

                return i;
            }

            return 0f;
        }
    }
}