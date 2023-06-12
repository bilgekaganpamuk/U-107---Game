using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public TextMeshProUGUI VolumeText; // UI element to display the volume
    public TextMeshProUGUI GraficText; // UI element to display the graphics quality level
    private float volume; // Volume value
    private int maxQualityIndex; // Maximum quality level index

    // This function is called when the object becomes active
    void Start()
    {
        // Initialize the volume text based on the saved volume preference, default to 10 if not set
        VolumeText.text = PlayerPrefs.GetFloat("volume", 10f).ToString();
        // Initialize the volume variable
        volume = PlayerPrefs.GetFloat("volume", 10f);
        // Get the maximum quality level index
        maxQualityIndex = QualitySettings.names.Length - 1;
    }

    // Function to increase the volume
    public void IncreaseVolume()
    {
        // Get the current volume
        volume = PlayerPrefs.GetFloat("volume", volume);

        // If the volume is less than 91 (to avoid going over 100)
        if (volume < 91)
        {
            // Increase the volume by 10
            volume = volume + 10;
            PlayerPrefs.SetFloat("volume", volume); // Save the volume
            AudioListener.volume = volume / 100; // Apply the volume change
            VolumeText.text = PlayerPrefs.GetFloat("volume", volume).ToString(); // Update the volume text
            PlayerPrefs.Save(); // Save the preference
        }
    }

    // Function to decrease the volume
    public void DecreaseVolume()
    {
        // Get the current volume
        volume = PlayerPrefs.GetFloat("volume", volume);
        // If the volume is more than 9 (to avoid going under 0)
        if (volume > 9)
        {
            volume = volume - 10; // Decrease the volume by 10
            PlayerPrefs.SetFloat("volume", volume); // Save the volume
            AudioListener.volume = volume / 100; // Apply the volume change
            VolumeText.text = PlayerPrefs.GetFloat("volume", volume).ToString(); // Update the volume text
            PlayerPrefs.Save(); // Save the preference
        }
    }

    // Function to set the graphics quality to low
    public void SelectLowGraphic()
    {
        PlayerPrefs.SetInt("graphicsQuality", 1); // Save the quality level
        GraficText.text = "Düsük"; // Update the graphics text
        QualitySettings.SetQualityLevel(1); // Apply the graphics quality level
        PlayerPrefs.Save(); // Save the preference
    }

    // Function to set the graphics quality to medium
    public void SelectMediumGraphic()
    {
        PlayerPrefs.SetInt("graphicsQuality", maxQualityIndex / 2); // Save the quality level
        GraficText.text = "Orta"; // Update the graphics text
        QualitySettings.SetQualityLevel(maxQualityIndex / 2); // Apply the graphics quality level
        PlayerPrefs.Save(); // Save the preference
    }

    // Function to set the graphics quality to max
    public void SelectMaxGraphic()
    {
        PlayerPrefs.SetInt("graphicsQuality", maxQualityIndex); // Save the quality level
        GraficText.text = "Yüksek"; // Update the graphics text
        QualitySettings.SetQualityLevel(maxQualityIndex); // Apply the graphics quality level
        PlayerPrefs.Save(); // Save the preference
    }
}
