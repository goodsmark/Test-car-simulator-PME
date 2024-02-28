using UnityEngine;
using Zenject;

public class Scene1UiC : MonoBehaviour
{
    [SerializeField] private Scene1CarSelectorUI selectorUI;
    [SerializeField] private Scene1LookAroundCar lookAroundCar;
    [SerializeField] private Scene1ButtonContent buttonContent;
    
    [Inject] private Scene1Controller _controller;
    private void Start()
    {
        selectorUI.Init(_controller.CarSelector.SelectNext, _controller.CarSelector.SelectNext);
        buttonContent.Init(_controller.StartRace);
        
        lookAroundCar.AddViewForHide(selectorUI.GetComponent<CanvasGroup>());
        lookAroundCar.AddViewForHide(buttonContent.GetComponent<CanvasGroup>());
    }
}
