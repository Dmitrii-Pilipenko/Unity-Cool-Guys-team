using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int count;
    [SerializeField] Vector3 vector;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-vector.x / 2, vector.x / 2),
                Random.Range(-vector.y / 2, vector.y / 2),
                Random.Range(-vector.z / 2, vector.z / 2)
            );
            
            Instantiate(prefab, randomPosition, Quaternion.identity);
        }
    }
}