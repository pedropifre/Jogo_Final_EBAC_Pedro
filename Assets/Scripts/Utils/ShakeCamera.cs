using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;
using Cinemachine;
public class ShakeCamera : Singleton<ShakeCamera>
{
    public CinemachineVirtualCamera virtualCamera;

    [Header("Shake Value")]
    public float amplitude = 3f;
    public float frequency = 3f;
    public float time = 3f;


    [NaughtyAttributes.Button]
    public void Shake()
    {
        ShakeCam(3f, 3f, .5f);
    }

    public float shakeTime;
    public void ShakeCam(float amplitiude, float frequency, float time)
    {
       
        if (virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>() != null)
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain= frequency;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitiude;
        }

        shakeTime = time;
    }

    private void Update()
    {
        if (shakeTime > 0)
        {
            shakeTime -= Time.deltaTime;
        }
        else
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;
        }
        
    }
}
