using UnityEngine;
using UnityEngine.SceneManagement;

public class GFPLS : MonoBehaviour
{
    void Awake()
    {
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
