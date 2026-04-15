using Unity.VisualScripting;
using UnityEngine;

public class RobotHealth : MonoBehaviour
{
    public Animator anim;
    public PlayerMovement movementScript;
    void Start()
    {
        if (movementScript == null)
        {
            movementScript = GetComponent<PlayerMovement>();
        }
    }
    public void TakeDamage(ElementType type)
    {
        Debug.Log("Наступил в парашу - ты умер");
        //movementScript.enabled = false;
        // if (type.isShock)
        // {
        //     Debug.Log("Накуканило током");
        //     anim.SetTrigger("Shocked");
        // }
        // else if (type.isInstatntDeath)
        // {
        //     Debug.Log("Сгорел в лаве");
        //     anim.SetTrigger("Melt");
        // }
        // Invoke("RestartLevel", 2f);
    }
}
