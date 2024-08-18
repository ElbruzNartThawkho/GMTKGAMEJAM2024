using Cinemachine;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public static CamShake instance;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float intensity;
    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        cinemachineBasicMultiChannelPerlin = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void ShakeCamera(float intensity, float time)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        this.intensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }
    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
                Mathf.Lerp(intensity, 0, shakeTimer / shakeTimerTotal);
            }
        }
    }
}
