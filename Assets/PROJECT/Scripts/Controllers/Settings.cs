using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static void Init()
    {
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
    }
}
