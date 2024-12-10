using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataManager : MonoBehaviour
{
    // Singleton instance
    public static DataManager instance;

    // Reference to UI elements
    public Slider[] sliders;
    public TMP_Dropdown[] dropdowns;
    public Toggle toggle;
    public TMP_InputField inputField;

    void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
        }

        // Load saved settings
        LoadSettings();
    }

    public void SaveSettings()
    {
        // Save settings to PlayerPrefs
        foreach (Slider slider in sliders)
        {
            PlayerPrefs.SetFloat(slider.name, slider.value);
        }

        foreach (TMP_Dropdown dropdown in dropdowns)
        {
            PlayerPrefs.SetInt(dropdown.name, dropdown.value);
        }

        PlayerPrefs.SetInt(toggle.name, toggle.isOn ? 1 : 0);
        PlayerPrefs.SetString(inputField.name, inputField.text);

        // Save PlayerPrefs
        PlayerPrefs.Save();
    }

    void LoadSettings()
    {
        // Load settings from PlayerPrefs
        foreach (Slider slider in sliders)
        {
            slider.value = PlayerPrefs.GetFloat(slider.name, slider.value);
        }

        foreach (TMP_Dropdown dropdown in dropdowns)
        {
            dropdown.value = PlayerPrefs.GetInt(dropdown.name, dropdown.value);
        }

        toggle.isOn = PlayerPrefs.GetInt(toggle.name, toggle.isOn ? 1 : 0) == 1;
        inputField.text = PlayerPrefs.GetString(inputField.name, inputField.text);
    }
}
