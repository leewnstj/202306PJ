using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;

    private CinemachineBasicMultiChannelPerlin _bPerinsNoise;

    private void Awake()
    {
        if (Instance != null) Debug.LogError("CameraManager!!!");

        Instance = this;

        var followCam = GameObject.Find("FollowCam").GetComponent<CinemachineVirtualCamera>();
        _bPerinsNoise = followCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void CamShake(float amplitude, bool value)
    {
        StartCoroutine(ShakeCamCoroutine(amplitude, value));
    }

    private IEnumerator ShakeCamCoroutine(float amplitude, bool value)
    {
        while(value)
        {
            _bPerinsNoise.m_AmplitudeGain = amplitude;
            yield return null;
        }

        _bPerinsNoise.m_AmplitudeGain = 0;
    }
}
