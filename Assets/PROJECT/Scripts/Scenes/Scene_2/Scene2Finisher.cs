using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Scene2Finisher : MonoBehaviour
{
    [Inject] private Scene2Controller _controller;
    private void OnTriggerEnter(Collider other)
    {
        var car = other.GetComponent<RCC_CarControllerV3>();

        if (car != null)
        {
            _controller.SwhowWinPopup();
        }
    }
}
