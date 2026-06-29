using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform mainCameraTransform;
    private Vector3 lockedPosition;

    private void Start()
    {
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }

        lockedPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (mainCameraTransform != null)
        {
            transform.position = lockedPosition;

            Vector3 targetPosition = new Vector3(mainCameraTransform.position.x, transform.position.y, mainCameraTransform.position.z);
            
            transform.LookAt(targetPosition);
            transform.Rotate(0, 180, 0);
        }
    }
}