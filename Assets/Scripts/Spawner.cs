//using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int number;
    [SerializeField] int radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 offset = Random.insideUnitSphere * radius;
            Vector3 aboba = transform.position + offset;
            Instantiate(prefab, aboba, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
