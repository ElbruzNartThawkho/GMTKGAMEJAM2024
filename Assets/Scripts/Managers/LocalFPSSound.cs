using UnityEngine;

public class LocalFPSSound : MonoBehaviour
{
    public void PlayLocalSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
