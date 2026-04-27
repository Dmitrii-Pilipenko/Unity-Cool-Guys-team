using UnityEngine;

public class HazardArea : MonoBehaviour
{
    public ElementType hazardType;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<RobotHealth>().TakeDamage(hazardType);
    }
}
