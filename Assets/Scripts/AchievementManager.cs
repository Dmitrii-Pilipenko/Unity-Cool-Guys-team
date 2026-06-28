using System.Collections.Generic;
using UnityEngine;
using System;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    public List<Achievement> database;
    private Dictionary<string, int> actionProgress = new Dictionary<string, int>();

    public event Action<Achievement> OnAchievementUnlocked;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public void ReportAction(string action, int amount = 1)
    {
        if (actionProgress.ContainsKey(action))
            actionProgress[action] += amount;
        else
            actionProgress.Add(action, amount);

        int currentAmount = actionProgress[action];
        foreach (var ach in database)
        {
            if (!ach.isUnlocked && ach.targetAction == action)
            {
                if (currentAmount >= ach.requiredAmount)
                {
                    Unlock(ach);
                }
            }
        }
    }

    private void Unlock(Achievement ach)
    {
        ach.isUnlocked = true;
        Debug.Log($"Ачивка получена: {ach.title}");
        OnAchievementUnlocked?.Invoke(ach);
    }
}