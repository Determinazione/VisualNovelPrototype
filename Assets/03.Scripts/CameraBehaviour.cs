using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraBehaviour : MonoBehaviour {

    [SerializeField]
    [Range(0f, 5f)]
    private float mShakingDuration;

    [SerializeField]
    [Range(0f, 3f)]
    private float mShakingStrength;

    [SerializeField]
    [Range(0, 50)]
    private int mShakingTimes;

    [SerializeField]
    [Range(0f, 90f)]
    private float mShakingAngle;

    private Camera mMainCamera;

    void Start()
    {
        mMainCamera = GetComponent<Camera>();

        mMainCamera.DOShakePosition(mShakingDuration, mShakingStrength, mShakingTimes, mShakingAngle, false);
    }
}
