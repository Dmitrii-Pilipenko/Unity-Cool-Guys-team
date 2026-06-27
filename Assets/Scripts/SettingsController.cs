using UnityEngine;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider mouseSensitivitySlider;

    private void Start()
    {
        volumeSlider.SetValueWithoutNotify(GameSettings.Volume);
        mouseSensitivitySlider.SetValueWithoutNotify(GameSettings.MouseSensitivity);

        GameSettings.Apply();
    }

    public void SetVolume(float value)
    {
        GameSettings.Volume = value;
    }

    public void SetMouseSensitivity(float value)
    {
        GameSettings.MouseSensitivity = value;
        Debug.Log("Saved sensitivity: " + value);
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}