using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraC
{
    public static Camera Camera;

    public static void Init()
    {
        Camera = Camera.main;
    }
}
