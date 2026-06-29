using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementItemView : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text statusText;

    public void Init(Achievement achievement)
    {
        titleText.text = achievement.title;
        descriptionText.text = achievement.description;

        if (achievement.icon != null)
        {
            iconImage.sprite = achievement.icon;
        }

        statusText.text = achievement.isUnlocked ? "Открыто" : "Не открыто";
    }
}