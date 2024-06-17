using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraShakeController : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;
    //NoiseSettings mynoisedef = Resources.("Assets");

    void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.AddCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        ResetIntensity();
    }

    public void ShakeCamera(float intensity, float shakeTime)
    {
        vCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = intensity;
        StartCoroutine(Wait(shakeTime));
    }

    IEnumerator Wait(float shakeTime)
    {
        yield return new WaitForSecondsRealtime(shakeTime);
        ResetIntensity();
    }

    private void ResetIntensity()
    {
        print("¸®¼Â");
        vCam.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
    }
}
