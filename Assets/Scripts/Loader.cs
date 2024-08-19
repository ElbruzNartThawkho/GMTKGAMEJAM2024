using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public string sceneName;

    private void GoScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GoScene();
        }
    }
}
