using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    public PlayerMovement movementScript;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject robotMesh;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (movementScript == null)
        {
            movementScript = GetComponent<PlayerMovement>();
        }
    }
    public void TakeDamage(ElementType type)
    {

        Die();
    }
    private void Die()
    {
        if (movementScript != null)
        {
            movementScript.enabled = false;
        }
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
            rb.isKinematic = true;

        }
        if (explosionPrefab != null)
        {
            GameObject exlposion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(exlposion, 2f);
        }
        if (robotMesh != null)
        {
            robotMesh.SetActive(false);
        }
        Debug.Log("Суши весла - ты приплыл");
        // Destroy(rb);

    }
    public void Revive()
    {
        if (robotMesh != null)
        {
            robotMesh.SetActive(true);
        }
        if (rb != null)
        {
            rb.isKinematic = false;
        }
        if (movementScript != null)
        {
            movementScript.enabled = true;
        }
        

    }
}
