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
        GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("MouseSens", 0.5f);
        GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = PlayerPrefs.GetFloat("MouseSens", 0.5f);
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
