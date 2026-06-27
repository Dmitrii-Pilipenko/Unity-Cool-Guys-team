using UnityEngine;

public static class GameSettings
{
    private const string VolumeKey = "volume";
    private const string MouseSensitivityKey = "mouseSensitivity";

    public const float DefaultVolume = 1f;
    public const float DefaultMouseSensitivity = 1f;

    public static float Volume
    {
        get => PlayerPrefs.GetFloat(VolumeKey, DefaultVolume);
        set
        {
            AudioListener.volume = value;
            PlayerPrefs.SetFloat(VolumeKey, value);
            PlayerPrefs.Save();
        }
    }

    public static float MouseSensitivity
    {
        get => PlayerPrefs.GetFloat(MouseSensitivityKey, DefaultMouseSensitivity);
        set
        {
            PlayerPrefs.SetFloat(MouseSensitivityKey, value);
            PlayerPrefs.Save();
        }
    }

    public static void Apply()
    {
        AudioListener.volume = Volume;
    }
}
