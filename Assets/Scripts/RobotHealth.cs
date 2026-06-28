using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    public PlayerMovement movementScript;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject robotMesh;
    [SerializeField] private Animator animator;
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
        AchievementManager.Instance.ReportAction("die"); 
        // AchievementManager.Instance.UnlockAchievement("First damage"); 
    }
    private void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isDie", true);
        }
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
        //if (explosionPrefab != null)
        //{
        //    GameObject exlposion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //    Destroy(exlposion, 2f);
        //}
        //if (robotMesh != null)
        //{
        //    robotMesh.SetActive(false);
        //}
        //Debug.Log("Суши весла - ты приплыл");
        //// Destroy(rb);
        ///
        StartCoroutine(DieCoroutine());

    }

    private IEnumerator DieCoroutine()
    {
        yield return null;
        float animLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);

        if (explosionPrefab != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
        }

        if (robotMesh != null)
        {
            robotMesh.SetActive(false);
        }
    }
    public void Revive()
    {
        if (animator != null)
        {
            animator.SetBool("isDie", false);
        }

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
            movementScript.ResetPolarity(); 
            Debug.Log("сработал скрипт ресета");
        }


    }
    
}
