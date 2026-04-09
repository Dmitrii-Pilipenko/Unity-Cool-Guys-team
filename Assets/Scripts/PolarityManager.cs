using UnityEngine;

public class PolarityManager : MonoBehaviour
{
    public bool isRed = true;
    private Renderer rend;
    
    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRed = !isRed;
            UpdateColor();
        }
    }
    private void UpdateColor()
    {
        if (isRed)
        {
            rend.material.color = Color.red;
        }
        else
        {
            rend.material.color = Color.blue;
        }
    }
}
