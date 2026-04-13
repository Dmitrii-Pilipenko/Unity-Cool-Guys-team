using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IControllable 
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] public float jumpForce = 6f;  
    private Rigidbody rb;
    private Camera mainCam;
    private bool isGrounded;
    private bool isOnFloor;
    private float inputH;
    private float inputV;
    private bool isNormalGravityPlayer = true;
    private Vector3 personalGravity = new Vector3(0, -9.81f, 0);
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
        rb.useGravity = false;
        InputManager manager = FindFirstObjectByType<InputManager>();
        if (manager != null)
        {
            manager.RegisterObject(this);
        }
        animator = GetComponent<Animator>();
    }
    public void Move(float horizontal, float vertical)
    {
        inputH = horizontal;
        inputV = vertical;
    }

    public void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        isOnFloor = Physics.Raycast(transform.position, Vector3.up, 1.1f);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else if (isOnFloor)
        {
            rb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
        }
    }
    public void ToggleGravity()
    {
        isNormalGravityPlayer = !isNormalGravityPlayer;       
        if (isNormalGravityPlayer)
        {
            personalGravity = new Vector3(0, -9.81f, 0);
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else
        {
            personalGravity = new Vector3(0, 9.81f, 0);  
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    private void FixedUpdate()
    {
        rb.AddForce(personalGravity, ForceMode.Acceleration);
        Vector3 camForward = mainCam.transform.forward;
        Vector3 camRight = mainCam.transform.right; 
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();        
        Vector3 moveDirection = (camForward * inputV + camRight * inputH).normalized;
        Vector3 newVelocity = moveDirection * speed;       
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        }
        float currentSpeed = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z).magnitude;

        if (animator != null)
        {
            animator.SetFloat("Speed", currentSpeed);
        }
    }
    void OnDestroy()
    {
        InputManager manager = FindFirstObjectByType<InputManager>();
        if (manager != null)
        {
            manager.UnregisterObject(this);
        }
    }
}