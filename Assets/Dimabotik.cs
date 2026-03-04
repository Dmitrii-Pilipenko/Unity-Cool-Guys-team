using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyScript : MonoBehaviour
{
    [SerializeField] [Header("StandartField")] int number;
    [SerializeField] string simpleString;

    [Space] [Tooltip("Это просто поле.")] [Range(3, 10)] public int field;

    [Min(7)] public int newInt;

    [TextArea] public string stringVar; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}