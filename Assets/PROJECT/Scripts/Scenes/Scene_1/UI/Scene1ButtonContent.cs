using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Scene1ButtonContent : MonoBehaviour
{
    [SerializeField] private Button startButton;

    [Inject] private Scene1Controller _controller;
    
    public void Init(Action startAction)
    {
        startButton.onClick.AddListener(startAction.Invoke);
    }
}
