using Cinemachine;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    public Animator animator;
    private PolarityManager playerPolarity;
    public CinemachineVirtualCamera vcamNormal;
    public CinemachineVirtualCamera vcamInverted;
    private bool playerFound = false;
    private Transform playerTransform;

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
        if (playerTransform == null)
        {
            playerTransform = playerPolarity.transform;
        }
    }

    public void SetCameraTarget(GameObject player)
    {
        playerTransform = player.transform;
        
        vcamNormal.Follow = playerTransform;
        vcamNormal.LookAt = playerTransform;
        vcamInverted.Follow = playerTransform;
        vcamInverted.LookAt = playerTransform;

        Debug.Log("Камера получила цель от Спавнера!");
    }

    void Update()
    {
        if (playerTransform == null) return;

        bool overThreshold = playerTransform.position.y > 5;
        animator.SetBool("isInverted", overThreshold);
    }
}
   