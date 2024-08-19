using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageSelector : MonoBehaviour
{
    TMP_Dropdown LangSelector;

    private void Awake()
    {
        LangSelector = GetComponent<TMP_Dropdown>();
    }

    private IEnumerator Start()
    {
        yield return LocalizationSettings.InitializationOperation;
        // PlayerPrefs'ten kayýtlý dil bilgisini kontrol et
        if (PlayerPrefs.HasKey("SelectedLanguage"))
        {
            int savedLanguageIndex = PlayerPrefs.GetInt("SelectedLanguage", 0);
            Debug.Log(savedLanguageIndex);
            // PlayerPrefs'ten alýnan dil indeksini kullanarak dil ayarýný yap
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[savedLanguageIndex];
            // TMP_Dropdown'ýn deðerini güncelle
            LangSelector.value = savedLanguageIndex;
        }
        else
        {
            // PlayerPrefs'te kayýtlý dil yoksa, varsayýlan olarak 0 (ilk dil) kullan
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            // TMP_Dropdown'ýn deðerini güncelle
            LangSelector.value = 0;
        }
    }

    public void OnSelect()
    {
        // TMP_Dropdown'tan seçilen dil indeksini al
        int selectedLanguageIndex = LangSelector.value;
        // LocalizationSettings'e seçilen dili ayarla
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[selectedLanguageIndex];

        // PlayerPrefs'e seçilen dil indeksini kaydet
        PlayerPrefs.SetInt("SelectedLanguage", selectedLanguageIndex);
        PlayerPrefs.Save(); // PlayerPrefs deðiþiklikleri kaydet
    }
}