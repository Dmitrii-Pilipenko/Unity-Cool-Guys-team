using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private bool isNoramlGravity = true;
    [SerializeField] public Transform wrap;
    [SerializeField] public Transform playerTransform;
    [SerializeField] public float speed = 7f;
    private Rigidbody rb;

    
    void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.transform.Rotate(12, speed, Time.deltaTime);
            ToggleGravity();
        }
    }

    void ToggleGravity()
    {
        isNoramlGravity = !isNoramlGravity;
        foreach (Transform child in wrap)
        {


            if (isNoramlGravity)
            {
                Physics.gravity = new Vector3(0, -9.81f, 0);
                playerTransform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                Physics.gravity = new Vector3(0, 9.81f, 0);
                playerTransform.localScale = new Vector3(1, -1, 1);
            }
        }
    }
}
