using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Scene1CameraSettings : MonoBehaviour
{
    public Transform cameraPos;
    public Transform cameraPosAfter;
    public Transform carPositionSpawn;

    private float animSpeed = 0.8f;
    private void Start()
    {
        CameraC.Camera.transform.SetPositionAndRotation(cameraPos.position, cameraPos.rotation);

        CameraC.Camera.transform.DOMove(cameraPosAfter.position, animSpeed);
        CameraC.Camera.transform.DORotate(cameraPosAfter.rotation.eulerAngles, animSpeed);
    }
}
