using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    //public GameObject finishScreen;
    //public Button nextLvl;
    //public Button[] lvlBtn;
    public TMP_Dropdown resDropDown, qualityDropdown;
    public Slider volumeSlider, brightnessSlider, mouseSensSlider;
    public AudioMixer mixer;
    public Volume globalVolume;
    private LiftGammaGain liftGammaGain;
    [HideInInspector] public string volume = "Volume", resolution = "Resulotion", quality = "QualityLevel", mouse = "MouseSensitivity", brightness = "Brightness", lvlInfo = "Lvl", mouseSens = "MouseSens";

    //public GameObject menu, setbtn; //public Player player;
    [HideInInspector] public PlayerInputs playerInputs;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetStartSoundValues(); SetStartResValues(); SetStartQualityValues(); SetStartBrightnessValues(); SetStartMouseSens();
        //if (lvlBtn.Length != 0)
        //{
        //    SetStartLvl();
        //}
        volumeSlider.onValueChanged.AddListener(SetSoundValues);
        brightnessSlider.onValueChanged.AddListener(SetBrightnessValue);
        resDropDown.onValueChanged.AddListener(SetResolutionValues);
        qualityDropdown.onValueChanged.AddListener(SetQualityLevel);
        mouseSensSlider.onValueChanged.AddListener(SetMouseSens);
        //if (menu != null && player != null)
        //{
        //    playerInputs = new PlayerInputs();
        //    playerInputs.UI.Enable();
        //    playerInputs.UI.MenuBtn.performed += HandleMenu;
        //}
    }

    private void SetMouseSens(float lvl)
    {
        PlayerPrefs.SetFloat(mouseSens, lvl);
    }
    public void SetStartMouseSens() => mouseSensSlider.value = PlayerPrefs.GetFloat(mouseSens, 0.5f);
    //public void Finish()
    //{
    //    //player.SetPlayerInput(false);
    //    //player.gamepanel.SetActive(false);
    //    //menu.SetActive(false);
    //    finishScreen.SetActive(true);
    //    nextLvl.Select();
    //}
    private void OnDisable()
    {
        try
        {
            //playerInputs.UI.MenuBtn.performed -= HandleMenu;
            //playerInputs.UI.Disable();
        }
        catch (Exception)
        {

        }
    }
    public void HandleMenu(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            //if (menu != null && player != null && finishScreen.activeSelf == false)
            //{
            //    setbtn.GetComponent<Button>().Select();
            //    menu.SetActive(true);
            //    player.SetPlayerInput(false);
            //}
        }
    }
    //private void SetStartLvl()
    //{
    //    if (PlayerPrefs.HasKey(lvlInfo))
    //    {
    //        int lvl = PlayerPrefs.GetInt(lvlInfo);
    //        SetLvl(lvl);
    //        for (int i = 0; i < lvl; i++)
    //        {
    //            lvlBtn[i].interactable = true;
    //        }
    //    }
    //    else
    //    {
    //        lvlBtn[0].interactable = true;
    //        SetLvl(1);
    //    }
    //}
    public void SetLvl(int lvl)
    {
        PlayerPrefs.SetInt(lvlInfo, lvl);
    }
    private void SetStartQualityValues()
    {
        //string[] qualityNames = { "Performant", "Balanced", "High Fidelity" };
        //qualityDropdown.ClearOptions();
        //qualityDropdown.AddOptions(qualityNames.ToList());

        int savedQualityLevel = PlayerPrefs.GetInt(quality, 2);
        qualityDropdown.value = savedQualityLevel;
    }

    public void SetQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt(quality, level);
    }

    private void SetStartResValues()
    {
        Resolution[] resolutions = Screen.resolutions;
        resDropDown.ClearOptions();
        foreach (Resolution res in resolutions)
        {
            string resString = res.width + " x " + res.height + " " + Convert.ToInt32(res.refreshRateRatio.value) + "Hz";
            resDropDown.options.Add(new TMP_Dropdown.OptionData(resString));
        }

        if (PlayerPrefs.HasKey(resolution))
        {
            string savedRes = PlayerPrefs.GetString(resolution);
            for (int i = 0; i < resDropDown.options.Count; i++)
            {
                if (resDropDown.options[i].text == savedRes)
                {
                    resDropDown.value = i;
                    break;
                }
            }
        }
        else
        {
            resDropDown.value = resDropDown.options.Count - 1;
        }

        resDropDown.RefreshShownValue();
    }

    public void SetResolutionValues(int index)
    {
        Resolution[] resolutions = Screen.resolutions;
        if (index >= 0 && index < resolutions.Length)
        {
            Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
            PlayerPrefs.SetString(resolution, resDropDown.options[index].text);
        }
    }
    private void SetStartBrightnessValues()
    {
        globalVolume.profile.TryGet(out liftGammaGain);
        if (PlayerPrefs.HasKey(brightness))
        {
            float savedBrightness = PlayerPrefs.GetFloat(brightness);
            brightnessSlider.value = savedBrightness;
            SetBrightnessValue(savedBrightness);
        }
        else
        {
            brightnessSlider.value = 0; // Default brightness value
            SetBrightnessValue(0);
        }
    }

    public void SetBrightnessValue(float brightness)
    {
        liftGammaGain.gain.Override(new Vector4(0, 0, 0, brightness));
        PlayerPrefs.SetFloat("Brightness", brightness);
    }

    public void SetStartSoundValues() => volumeSlider.value = PlayerPrefs.GetFloat(volume, 0);

    public void SetSoundValues(float soundLvl)
    {
        mixer.SetFloat(volume, soundLvl);
        PlayerPrefs.SetFloat(volume, soundLvl);
    }

    public void GoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); Time.timeScale = 1;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); Time.timeScale = 1;
    }
    public void Exit() => Application.Quit();
}