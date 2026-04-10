using Cinemachine;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    public Animator animator;
    private PolarityManager playerPolarity;
    public CinemachineVirtualCamera vcamNormal;
    public CinemachineVirtualCamera vcamInverted;
    private bool playerFound = false;

    void Start()
    {
        if (vcamNormal == null)
        {
            vcamNormal = transform.Find("vcam_Normal")?.GetComponent<CinemachineVirtualCamera>();
        }
        if (vcamInverted == null)
        {
            vcamInverted = transform.Find("vcam_Inverted")?.GetComponent<CinemachineVirtualCamera>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (playerPolarity == null)
        {
            playerPolarity = Object.FindAnyObjectByType<PolarityManager>();
            if (playerPolarity != null)
            {
                Transform target = playerPolarity.transform;
                vcamNormal.Follow = target;
                vcamNormal.LookAt = target;
                vcamInverted.Follow = target;
                vcamInverted.LookAt = target;
                //Debug.Log("Камера наконец то нашлась ЮХУ");
            }
        }
        else
        {
            animator.SetBool("isInverted", !playerPolarity.isRed);
        }

    }
}
   