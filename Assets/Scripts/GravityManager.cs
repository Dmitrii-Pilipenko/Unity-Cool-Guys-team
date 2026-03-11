using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private bool isNoramlGravity = true;
    [SerializeField] public Transform playerTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ToggleGravity();
        }
    }

    void ToggleGravity()
    {
        isNoramlGravity = !isNoramlGravity;
        if (isNoramlGravity)
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
            playerTransform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
            playerTransform.localScale = new Vector3(1, -1, 1);
        }
    }
}
