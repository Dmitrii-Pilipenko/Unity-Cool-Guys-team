using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public void Play()
    {
        Debug.Log("Start Game");
        // SceneManager.LoadScene("—цена с игрой");
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
