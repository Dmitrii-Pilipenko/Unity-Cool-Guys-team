using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private string defaultLevel = "1 level";

    public void OpenLevels()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settingsPanel.SetActive(false);
        levelsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ContinueGame()
    {
        string scene = LevelProgress.HasLastLevel ? LevelProgress.LastLevel : defaultLevel;
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}