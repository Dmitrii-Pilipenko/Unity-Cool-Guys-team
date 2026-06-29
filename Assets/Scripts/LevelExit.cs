using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [Header("Настройки перехода")]
    public string nextLevelName;
    private bool isPlayerNear = false;
    public GameObject hintUI;

    private void Start()
    {
        if (hintUI != null) hintUI.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E)) LoadNextLevel();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (hintUI != null) hintUI.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) isPlayerNear = false;
        if (hintUI != null) hintUI.SetActive(false);
    }
    private void LoadNextLevel()
    {
        Debug.Log("Загрузка уровня"); //желательно скрыть ее добавить лоадскрин
        SceneManager.LoadScene(nextLevelName);

    }
}
