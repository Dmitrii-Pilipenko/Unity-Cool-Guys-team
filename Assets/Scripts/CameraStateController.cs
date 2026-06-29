using Cinemachine;
using UnityEngine;

public class CameraStateController : MonoBehaviour
{
    [Header("Степа и Дима тут надо всегда кидать границы комнаты (пол и потолок)")]
    [SerializeField] private Transform roomFloor;
    [SerializeField] private Transform roomCeiling;
   // [SerializeField] private Transform worldGravityTracker;
    private float thresholdY;
    private Animator animator;
    // private PolarityManager playerPolarity;
    public CinemachineFreeLook vcamNormal;
    public CinemachineFreeLook vcamInverted;
    //private bool playerFound = false;
    private Transform player;
    //  private float currentWorldZ = 0f;

    private float baseNormalX, baseNormalY;
    private float baseInvertedX, baseInvertedY;


    void Awake()
    {
        animator = GetComponent<Animator>();

        if (vcamNormal != null)
        {
            baseNormalX = vcamNormal.m_XAxis.m_MaxSpeed;
            baseNormalY = vcamNormal.m_YAxis.m_MaxSpeed;
        }
        if (vcamInverted != null)
        {
            baseInvertedX = vcamInverted.m_XAxis.m_MaxSpeed;
            baseInvertedY = vcamInverted.m_YAxis.m_MaxSpeed;
        }
    }

    private void ApplyMouseSensitivity()
    {
        float s = GameSettings.MouseSensitivity;

        if (vcamNormal != null)
        {
            vcamNormal.m_XAxis.m_MaxSpeed = baseNormalX * s;
            vcamNormal.m_YAxis.m_MaxSpeed = baseNormalY * s;
        }
        if (vcamInverted != null)
        {
            vcamInverted.m_XAxis.m_MaxSpeed = baseInvertedX * s;
            vcamInverted.m_YAxis.m_MaxSpeed = baseInvertedY * s;
        }
    }
    public void InitCamera(GameObject spawnedPlayer)
    {
        player = spawnedPlayer.transform;
        Transform lookPoint = player.Find("CameraTarget");

        if (lookPoint != null)
        {
            if (vcamNormal != null) vcamNormal.Follow = lookPoint; vcamNormal.LookAt = lookPoint;

            if (vcamInverted!= null) vcamInverted.Follow = lookPoint; vcamInverted.LookAt = lookPoint;
        }
        else Debug.LogError("Дубина напортачил");
        CalculateThreshold();

    }

    private void CalculateThreshold()
    {
        if (roomCeiling != null && roomFloor != null) thresholdY = (roomFloor.position.y + roomCeiling.position.y) * 0.5f;
        else Debug.LogError("ТЫ ЧШОРТ И НЕ ДОБАВИЛ ПОЛ ИЛИ ПОТОЛОК в инспекторе (координаты)");
    }

    void Update()
    {
        ApplyMouseSensitivity();

        if (player == null) return;
        

        bool overThreshold = player.position.y > thresholdY;
        animator.SetBool("isInverted", overThreshold);
        // if (worldGravityTracker != null)
        // {
        //     float targetZ = overThreshold ? 180f : 0f;
        //     currentWorldZ = Mathf.MoveTowardsAngle(currentWorldZ, targetZ, 250f * Time.deltaTime);
        //     worldGravityTracker.rotation = Quaternion.Euler(0, 0, currentWorldZ);
        // }
    }
}
   