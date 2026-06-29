using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelProgress
{
    private const string LastLevelKey = "lastLevel";
    private static readonly string[] NonLevelScenes = { "Menu" };
    public static bool HasLastLevel => PlayerPrefs.HasKey(LastLevelKey);

    public static string LastLevel
    {
        get => PlayerPrefs.GetString(LastLevelKey, string.Empty);
        private set
        {
            PlayerPrefs.SetString(LastLevelKey, value);
            PlayerPrefs.Save();
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (var name in NonLevelScenes)
            if (scene.name == name) return;

        LastLevel = scene.name;
    }
}