using UnityEngine;

public class HazardArea : MonoBehaviour
{
    [SerializeField] private GameObject zap;
    public ElementType hazardType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (zap != null)
            {
                Vector3 spawnPos = other.transform.position;
                GameObject spawnedZap = Instantiate(zap, spawnPos, Quaternion.identity);
                Destroy(spawnedZap, 2f);
                Debug.Log("Тебя пожарили как шкурку");


            }
            RobotHealth health = other.GetComponent<RobotHealth>();
            if (health != null)
            {
                health.TakeDamage(hazardType);
            }
            if (SpawnManager.Instance != null)
            {
                SpawnManager.Instance.Relocate(other.gameObject);
            }

        }

        
    }
}
