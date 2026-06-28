using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievements/Achievement Data")]
public class Achievement : ScriptableObject
{
    public string id;
    public string title;
    [TextArea] public string description;
    public Sprite icon;

    [Header("Условия для ачивок")]
    public string targetAction;
    public int requiredAmount = 1;


    [HideInInspector]
    public bool isUnlocked;
}
