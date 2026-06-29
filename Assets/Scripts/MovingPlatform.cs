using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Стены, между которыми ездит платформа")]
    [SerializeField] private Collider wallA;
    [SerializeField] private Collider wallB;

    [Header("Движение")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float waitTime = 1f;

    private int axis;
    private float minPos;
    private float maxPos;
    private int direction = 1;
    private bool isWaiting = false;

    void Start()
    {
        if (wallA == null || wallB == null)
        {
            Debug.LogError("MovingPlatform: назначь обе стены (Wall A и Wall B).", this);
            enabled = false;
            return;
        }

        CalculateBounds();
    }

    void CalculateBounds()
    {
        Vector3 delta = wallB.bounds.center - wallA.bounds.center;
        axis = Mathf.Abs(delta.x) >= Mathf.Abs(delta.z) ? 0 : 2;

        float half = transform.lossyScale[axis] * 0.5f;

        if (wallA.bounds.center[axis] < wallB.bounds.center[axis])
        {
            minPos = wallA.bounds.max[axis] + half;
            maxPos = wallB.bounds.min[axis] - half;
        }
        else
        {
            minPos = wallB.bounds.max[axis] + half;
            maxPos = wallA.bounds.min[axis] - half;
        }
    }

    void Update()
    {
        if (isWaiting) return;

        Vector3 pos = transform.position;
        pos[axis] += direction * speed * Time.deltaTime;

        if (pos[axis] >= maxPos)
        {
            pos[axis] = maxPos;
            StartCoroutine(WaitAndReverse());
        }
        else if (pos[axis] <= minPos)
        {
            pos[axis] = minPos;
            StartCoroutine(WaitAndReverse());
        }

        transform.position = pos;
    }

    IEnumerator WaitAndReverse()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        direction *= -1;
        isWaiting = false;
    }
}