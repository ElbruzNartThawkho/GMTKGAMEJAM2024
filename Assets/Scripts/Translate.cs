using UnityEngine;
using TMPro;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    TMP_Dropdown LangSelector;

    private void Awake()
    {
        LangSelector = GetComponent<TMP_Dropdown>();
    }

    private void Start()
    {
        // PlayerPrefs'ten kay�tl� dil bilgisini kontrol et
        if (PlayerPrefs.HasKey("SelectedLanguage"))
        {
            int savedLanguageIndex = PlayerPrefs.GetInt("SelectedLanguage", 0);
            // PlayerPrefs'ten al�nan dil indeksini kullanarak dil ayar�n� yap
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[savedLanguageIndex];
            // TMP_Dropdown'�n de�erini g�ncelle
            LangSelector.value = savedLanguageIndex;
        }
        else
        {
            // PlayerPrefs'te kay�tl� dil yoksa, varsay�lan olarak 0 (ilk dil) kullan
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            // TMP_Dropdown'�n de�erini g�ncelle
            LangSelector.value = 0;
        }
    }

    public void OnSelect()
    {
        // TMP_Dropdown'tan se�ilen dil indeksini al
        int selectedLanguageIndex = LangSelector.value;
        // LocalizationSettings'e se�ilen dili ayarla
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[selectedLanguageIndex];

        // PlayerPrefs'e se�ilen dil indeksini kaydet
        PlayerPrefs.SetInt("SelectedLanguage", selectedLanguageIndex);
        PlayerPrefs.Save(); // PlayerPrefs de�i�iklikleri kaydet
    }
}