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

    public void CamShake(float amplitude)
    {
        _bPerinsNoise.m_AmplitudeGain = amplitude;
    }
}
