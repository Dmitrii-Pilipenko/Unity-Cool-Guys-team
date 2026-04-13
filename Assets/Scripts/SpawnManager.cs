using Cinemachine;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public static SpawnManager Instance;

    void Start()
    {
        SpawnCube();
    }
    public void SpawnCube()
    {
        Debug.Log("Spawning player...");
        if (player == null) Debug.LogError("Player prefab is NULL!");
        if (spawnPoint == null) Debug.LogError("SpawnPoint is NULL!");
        if (player != null && spawnPoint != null)
        {
            GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            CinemachineVirtualCamera vcam = FindFirstObjectByType<CinemachineVirtualCamera>();
            if (vcam != null)
            {
                vcam.Follow = newPlayer.transform;
                vcam.LookAt = newPlayer.transform;
            }
        }
    }
    void Awake()
    {
        Instance = this;
    }
}