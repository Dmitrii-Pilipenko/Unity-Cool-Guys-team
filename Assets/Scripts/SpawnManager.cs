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