using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float turnSpeed = 10f;
    [SerializeField] public float jumpForce = 6f;
    private Rigidbody rb;
    private Camera mainCam;
    private bool isGrounded;
    private bool isGrounded2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        isGrounded2 = Physics.Raycast(transform.position, Vector3.up, 1.1f);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 camForward = mainCam.transform.forward;
        Vector3 camRight = mainCam.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();
        Vector3 moveDirection = (camForward * v + camRight * h).normalized;
        Vector3 newVelocity = moveDirection * speed;
        if (isGrounded || isGrounded2)
        {
            
            newVelocity.y = rb.linearVelocity.y;
            rb.linearVelocity = newVelocity;
        }

            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
            }


        }


        public void Update()
        {

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }

