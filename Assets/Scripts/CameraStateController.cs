using Cinemachine;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    [Header("Степа и Дима тут надо всегда кидать границы комнаты (пол и потолок)")]
    [SerializeField] private Transform roomFloor;
    [SerializeField] private Transform roomCeiling;
    private float thresholdY;
    public Animator animator;
    private PolarityManager playerPolarity;
    public CinemachineVirtualCamera vcamNormal;
    public CinemachineVirtualCamera vcamInverted;
    //private bool playerFound = false;
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
        CalculateThreshold();

        //Debug.Log("Камера получила цель от Спавнера!");
    }
    private void CalculateThreshold()
    {
        if (roomCeiling != null && roomFloor != null) thresholdY = (roomFloor.position.y + roomCeiling.position.y) * 0.5f;
        else Debug.LogError("ТЫ ЧШОРТ И НЕ ДОБАВИЛ ПОЛ ИЛИ ПОТОЛОК в инспекторе (координаты)");
    }

    void Update()
    {
        if (playerTransform == null) return;

        bool overThreshold = playerTransform.position.y > thresholdY;
        animator.SetBool("isInverted", overThreshold);
    }
}
   