using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraRotation : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float flipDuration = 0.5f;
    private bool isFlipped = false;
    private Coroutine rotateCoroutine;

    public void FlipCamera()
    {
        isFlipped = !isFlipped;
        float targetDutch = isFlipped ? 180f : 0f;
        if (rotateCoroutine != null) StopCoroutine(rotateCoroutine);
        rotateCoroutine = StartCoroutine(RotateDutch(targetDutch));

    }
    IEnumerator RotateDutch(float target)
    {
        float startDutch = vcam.m_Lens.Dutch;
        float elapsed = 0;
        while (elapsed < flipDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / flipDuration;
            vcam.m_Lens.Dutch = Mathf.Lerp(startDutch, target, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
        vcam.m_Lens.Dutch = target;
    }
}
