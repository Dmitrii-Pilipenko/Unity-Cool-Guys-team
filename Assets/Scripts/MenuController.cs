using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;

    private void Awake()
    {
        if (mainMenuPanel == null || settingsPanel == null)
        {
            Debug.LogError("Menu panels not assigned!");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("IvanSpace");
    }

    public void OpenSettings()
    {
        SetPanels(false, true);
    }

    public void CloseSettings()
    {
        SetPanels(true, false);
    }

    private void SetPanels(bool main, bool settings)
    {
        mainMenuPanel.SetActive(main);
        settingsPanel.SetActive(settings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
