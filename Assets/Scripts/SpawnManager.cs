using Cinemachine;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;

    void Start()
    {
        SpawnCube();
    }
    public void SpawnCube()
    {
        if (player != null && spawnPoint != null)
        {
            GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            CameraStateController camController = FindAnyObjectByType<CameraStateController>();
            if (camController != null)
            {
                camController.SetCameraTarget(newPlayer);
            }
        }
    }
}