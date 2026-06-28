using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour, IControllable
{
    [Header("Настройки")]
    public float speed = 7f;
    public float jumpForce = 8f;
    public float gravity = 15f; 
    private CharacterController controller;
    private Transform cameraTransform;
    private Vector3 velocity;
    private InputManager inputManager;
    private Animator animator;
    private bool isNormalGravityPlayer = true;
    private float currentTiltZ = 0f; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        if (Camera.main != null) cameraTransform = Camera.main.transform;

        inputManager = FindObjectOfType<InputManager>();
        if (inputManager != null) inputManager.RegisterObject(this);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Move(float horizontal, float vertical)
    {
        bool hitCeiling = (controller.collisionFlags & CollisionFlags.Above) != 0;
        bool isGroundedNow = isNormalGravityPlayer ? controller.isGrounded : hitCeiling;

        if (isGroundedNow)
        {
            if (isNormalGravityPlayer && velocity.y < 0) velocity.y = -2f;
            if (!isNormalGravityPlayer && velocity.y > 0) velocity.y = 2f;
        }

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

<<<<<<< HEAD
=======
        // ПЛАВНЫЙ ПЕРЕВОРОТ (без дерганий)
>>>>>>> 499c324e0609feb6578f226ebee0be8f8aeade2b
        float targetTiltZ = isNormalGravityPlayer ? 0f : 180f;
        currentTiltZ = Mathf.MoveTowardsAngle(currentTiltZ, targetTiltZ, 600f * Time.deltaTime);

        if (inputDir.magnitude >= 0.1f && cameraTransform != null)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, currentTiltZ);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, currentTiltZ);
        }

        float absG = Mathf.Abs(gravity);
        float currentGravity = isNormalGravityPlayer ? -absG : absG;
        velocity.y += currentGravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (animator != null)
        {
            animator.SetFloat("Blend", inputDir.magnitude);
            bool isFlipping = Mathf.Abs(Mathf.DeltaAngle(currentTiltZ, targetTiltZ)) > 1f;
            animator.SetBool("isGround", isGroundedNow || isFlipping);
        }
    }

    public void Jump()
    {
        bool hitCeiling = (controller.collisionFlags & CollisionFlags.Above) != 0;
        bool isGroundedNow = isNormalGravityPlayer ? controller.isGrounded : hitCeiling;

        if (isGroundedNow)
        {
            velocity.y = isNormalGravityPlayer ? jumpForce : -jumpForce;
        }
        AchievementManager.Instance.ReportAction("jump"); 
    }

    public void ToggleGravity()
    {
        isNormalGravityPlayer = !isNormalGravityPlayer;
        velocity.y = 0f;

        Vector3 detachForce = isNormalGravityPlayer ? Vector3.down : Vector3.up;
        controller.Move(detachForce * 0.15f);
    }
    public void ResetPolarity() //обнуляем после смерти хотфикс
    {
        isNormalGravityPlayer = true;
        velocity.y = 0f;
        Vector3 detachForce = isNormalGravityPlayer ? Vector3.down : Vector3.up;
        controller.Move(detachForce * 0.15f);
    }

    private void OnDestroy()
    {
        if (inputManager != null) inputManager.UnregisterObject(this);
    }
}