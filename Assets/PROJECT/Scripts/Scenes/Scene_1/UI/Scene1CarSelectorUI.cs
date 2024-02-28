using System;
using UnityEngine;
using UnityEngine.UI;

public class Scene1CarSelectorUI : MonoBehaviour
{
    [SerializeField] private Button nexBtn;
    [SerializeField] private Button prewBtn;

    private Action _selectNext;
    private Action _selectPrevious;
    
    
    public void Init(Action selectNext, Action selectPrevious)
    {
        _selectNext = selectNext;
        _selectPrevious = selectPrevious;
            
        nexBtn.onClick.AddListener(OnNextButtonPressed);
        prewBtn.onClick.AddListener(OnPreviousButtonPressed);
    }

    private void OnNextButtonPressed()
    {
        _selectNext?.Invoke();
    }
    
    private void OnPreviousButtonPressed()
    {
        _selectPrevious?.Invoke();
    }
}
