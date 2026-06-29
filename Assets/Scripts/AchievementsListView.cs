using UnityEngine;

public class AchievementsListView : MonoBehaviour
{
    [SerializeField] private Transform contentParent;
    [SerializeField] private AchievementItemView achievementItemPrefab;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        if (AchievementManager.Instance == null)
        {
            Debug.LogError("AchievementManager не найден на сцене");
            return;
        }

        foreach (Achievement achievement in AchievementManager.Instance.database)
        {
            AchievementItemView item = Instantiate(achievementItemPrefab, contentParent);
            item.Init(achievement);
        }
    }
}