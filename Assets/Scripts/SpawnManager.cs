using System.Collections;
using Cinemachine;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public static SpawnManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        SpawnPlayer();
    }
    public void SpawnPlayer()
    {
        if (player != null && spawnPoint != null)
        {
            GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            CameraStateController camController = FindAnyObjectByType<CameraStateController>();
            if (camController != null)
            {
                camController.InitCamera(newPlayer);
            }
        }
    }
    public void Relocate(GameObject playerObj)
    {
        StartCoroutine(Respawn(playerObj));

    }
    private IEnumerator Respawn(GameObject playerObj)
    {
        yield return new WaitForSeconds(1.0f);
        if (spawnPoint == null) yield break;
        playerObj.transform.position = spawnPoint.position;
        if (playerObj.TryGetComponent(out Rigidbody rb))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (playerObj.TryGetComponent(out RobotHealth health))
        {
            health.Revive();
        }
    }
}