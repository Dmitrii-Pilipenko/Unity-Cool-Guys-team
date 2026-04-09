using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.Instance.SpawnCube();
            Destroy(other.gameObject);
        }
    }
}