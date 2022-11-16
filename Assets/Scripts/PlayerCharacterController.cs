using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    PlayerInputHandler m_InputHandler;
    [Header("Rotation")]
    [Tooltip("Rotation speed for moving the camera")]
    public float RotationSpeed = 200f;
    [Range(0.1f, 1f)]
    [Tooltip("Rotation speed multiplier when aiming")]
    public float AimingRotationMultiplier = 0.4f;
    float m_CameraVerticalAngle = 0f;

    PlayerWeaponsManager m_WeaponsManager;

    [Header("References")]
    [Tooltip("Reference to the main camera used for the player")]
    public Camera PlayerCamera;

    [Tooltip("Multiplicator for the sprint speed (based on grounded speed)")]
    public float SprintSpeedModifier = 2f;

    [Header("Movement")]
    [Tooltip("Max movement speed when grounded (when not sprinting)")]
    public float MaxSpeedOnGround = 10f;

    public float SpeedMovement = 3f;
    public CharacterController CharacterPlayerController;
    private void Start()
    {
        m_InputHandler = GetComponent<PlayerInputHandler>();

    }

    //public float RotationMultiplier
    //{
    //    get
    //    {
    //        if (m_WeaponsManager.IsAiming)
    //        {
    //            return AimingRotationMultiplier;
    //        }
    //        return 1f;
    //    }
    //}
    private void Update()
    {
        HandleCharacterMovement();
      
    }
    void HandleCharacterMovement()
    {
        // horizontal character rotation
        {
            // rotate the transform with the input speed around its local Y axis
            transform.Rotate(new Vector3(0f, (m_InputHandler.GetLookInputsHorizontal() * RotationSpeed /** RotationMultiplier*/), 0f), Space.Self);
        }

        // vertical camera rotation
        {
            // add vertical inputs to the camera's vertical angle
            m_CameraVerticalAngle += m_InputHandler.GetLookInputsVertical() * RotationSpeed /** RotationMultiplier*/;

            // limit the camera's vertical angle to min/max
            m_CameraVerticalAngle = Mathf.Clamp(m_CameraVerticalAngle, -89f, 89f);

            PlayerCamera.transform.localEulerAngles = new Vector3(m_CameraVerticalAngle, 0, 0);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * SpeedMovement * Time.deltaTime);

   //     CharacterPlayerController.Move(-1*movement.normalized * SpeedMovement * Time.deltaTime);
    }

    
}

