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
    public Vector3 CharacterVelocity { get; set; }

    public float SpeedMovement = 3f;
    public CharacterController m_Controller;
    public float HpPlayer;
    public float JumpForce;
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
        Vector3 CharacterVelocity = new Vector3(x, 0, z);

        //if (Input.GetKeyDown("space"))
        //{
        //    Debug.Log("space");
        //    // start by canceling out the vertical component of our velocity
        //    CharacterVelocity = new Vector3(CharacterVelocity.x, 0f, CharacterVelocity.z);

        //    // then, add the jumpSpeed value upwards
        //    CharacterVelocity += Vector3.up * JumpForce;

        //}

          transform.Translate(CharacterVelocity * SpeedMovement * Time.deltaTime);
        //m_Controller.Move(CharacterVelocity * SpeedMovement * Time.deltaTime);

    }
    //void GroundCheck()
    //{
    //    // Make sure that the ground check distance while already in air is very small, to prevent suddenly snapping to ground
    //    float chosenGroundCheckDistance =
    //        IsGrounded ? (m_Controller.skinWidth + GroundCheckDistance) : k_GroundCheckDistanceInAir;

    //    // reset values before the ground check
    //    IsGrounded = false;
    //    m_GroundNormal = Vector3.up;

    //    // only try to detect ground if it's been a short amount of time since last jump; otherwise we may snap to the ground instantly after we try jumping
    //    if (Time.time >= m_LastTimeJumped + k_JumpGroundingPreventionTime)
    //    {
    //        // if we're grounded, collect info about the ground normal with a downward capsule cast representing our character capsule
    //        if (Physics.CapsuleCast(GetCapsuleBottomHemisphere(), GetCapsuleTopHemisphere(m_Controller.height),
    //            m_Controller.radius, Vector3.down, out RaycastHit hit, chosenGroundCheckDistance, GroundCheckLayers,
    //            QueryTriggerInteraction.Ignore))
    //        {
    //            // storing the upward direction for the surface found
    //            m_GroundNormal = hit.normal;

    //            // Only consider this a valid ground hit if the ground normal goes in the same direction as the character up
    //            // and if the slope angle is lower than the character controller's limit
    //            if (Vector3.Dot(hit.normal, transform.up) > 0f &&
    //                IsNormalUnderSlopeLimit(m_GroundNormal))
    //            {
    //                IsGrounded = true;

    //                // handle snapping to the ground
    //                if (hit.distance > m_Controller.skinWidth)
    //                {
    //                    m_Controller.Move(Vector3.down * hit.distance);
    //                }
    //            }
    //        }
    //    }
    //}
    private void OnEnable()
    {
        EventManager.HitPlayer += Damage;
    }
    public void OnDisable()
    {
        EventManager.HitPlayer -= Damage;
    }
    public void Damage()
    {
        if (Random.RandomRange(1, 7) == 3)
        {
            //  Debug.Log(HpPlayer);
            HpPlayer -= 100;
            UiController._instance.EnableHitZone();
            MainUi._instance.ChangeFillAmountHealth();
            UiController._instance.CountTimeHizone = 0f;
            if (HpPlayer <= 0)
            {
                UiController._instance.ActiveEndGameUi();
                gameObject.SetActive(false);
            }
        }

    }
}

