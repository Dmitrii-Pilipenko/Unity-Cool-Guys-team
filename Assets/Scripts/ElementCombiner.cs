using Unity.VisualScripting;
using UnityEngine;

public class ElementCombiner : MonoBehaviour
{
    public GameObject rockPlatformPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Instantiate(rockPlatformPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
