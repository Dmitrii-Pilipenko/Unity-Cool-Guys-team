using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset;
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

}
