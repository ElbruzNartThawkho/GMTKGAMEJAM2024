using UnityEngine;

public class Effect : MonoBehaviour
{
    ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        Invoke(nameof(Res), particle.main.duration);
    }
    void Res()
    {
        gameObject.SetActive(false);
    }
}
