using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, IControllable 
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] public float jumpForce = 6f;
    [SerializeField] Animator animator;
    private Rigidbody rb;
    private Camera mainCam;
    private bool isGrounded;
    private bool isOnFloor;
    private float inputH;
    private float inputV;
    private bool isNormalGravityPlayer = true;
    private Vector3 personalGravity = new Vector3(0, -9.81f, 0);


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
            animator.SetBool("isGround", false);
        }
        else if (isOnFloor)
        {
            rb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
            animator.SetBool("isGround", false);
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
    public void Update()
    {
        float moveAmount = new Vector2(inputH, inputV).magnitude;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        animator.SetBool("isGround", isGrounded);
        animator.SetFloat("Blend", moveAmount);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    animator.SetTrigger("attack");
        //}
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

    }
}