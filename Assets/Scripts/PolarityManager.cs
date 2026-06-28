using UnityEngine;

public class PolarityManager : MonoBehaviour //мб можно и удалить нафиг этот скрипт
{
    public bool isRed = true;
    [SerializeField] private Renderer rend;
    void Start()
    {
        if (rend == null) {
            rend = GetComponent<Renderer>();
            
        }
        UpdateColor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRed = !isRed;
            UpdateColor();
            AchievementManager.Instance.ReportAction("shift"); 
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
