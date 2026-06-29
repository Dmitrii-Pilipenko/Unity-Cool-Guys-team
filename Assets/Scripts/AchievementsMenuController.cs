using UnityEngine;

public class AchievementsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject achievementsPanel;

    public void OpenAchievements()
    {
        mainMenuPanel.SetActive(false);
        achievementsPanel.SetActive(true);
    }

    public void CloseAchievements()
    {
        achievementsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}