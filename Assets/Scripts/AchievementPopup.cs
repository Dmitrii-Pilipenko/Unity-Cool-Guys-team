using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class AchievementPopup : MonoBehaviour
{
    private UIDocument uiDocument;
    
    [Header("Настройки")]
    public float displayTime = 3f;

    private VisualElement popupContainer;
    private Label titleLabel;
    private Label descLabel;
    private VisualElement iconElement;

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        var root = uiDocument.rootVisualElement;
        popupContainer = root.Q<VisualElement>("PopupContainer");
        titleLabel = root.Q<Label>("Title");
        descLabel = root.Q<Label>("Description");
        iconElement = root.Q<VisualElement>("Icon");
    }

    private void Start()
    {
        if (AchievementManager.Instance != null)
        {
            AchievementManager.Instance.OnAchievementUnlocked += ShowPopup;
            Debug.Log("UI подключился все збс");
        }
        else
        {
            Debug.LogError("UI ОШИБКА");
        }
    }

    private void OnDisable()
    {
        if (AchievementManager.Instance != null)
        {
            AchievementManager.Instance.OnAchievementUnlocked -= ShowPopup;
        }
    }

    private void ShowPopup(Achievement ach)
    {
        titleLabel.text = ach.title;
        descLabel.text = ach.description;
        
        if (ach.icon != null)
        {
            iconElement.style.backgroundImage = new StyleBackground(ach.icon);
        }

        StopAllCoroutines();
        StartCoroutine(AnimatePopupRoutine());
    }

    private IEnumerator AnimatePopupRoutine()
    {
        popupContainer.AddToClassList("popup-container--show");

        yield return new WaitForSeconds(displayTime);

        popupContainer.RemoveFromClassList("popup-container--show");
    }
}