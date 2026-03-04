using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float turnSpeed = 10f;
    private Rigidbody rb;
    private Camera mainCam;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
    }
    private void FixedUpdate()
    {
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
        newVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = newVelocity;
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
;
        rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
        }
    }


    void Update()
    {
        
    }
}
