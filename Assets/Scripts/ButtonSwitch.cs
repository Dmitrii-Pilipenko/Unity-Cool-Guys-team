using UnityEngine;
using UnityEngine.Events;

public class ButtonSwitch : MonoBehaviour
{
    public UnityEvent onPressed;
    private bool isPressed;
    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Box")) && !isPressed)
        {
            isPressed = true;
            transform.position -= new Vector3(0, 0.2f, 0);
            onPressed.Invoke();
        }
    }
}
