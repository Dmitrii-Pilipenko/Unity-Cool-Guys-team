using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "Game/ElementType")]
public class ElementType : ScriptableObject
{
    public string elementName;
    public bool isInstatntDeath;
    public bool isShock;
}
