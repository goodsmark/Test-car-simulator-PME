using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Zenject;

public class Scene2Controller : MonoBehaviour
{
    public static int carIndex;
    [SerializeField] private CanvasGroup uiControlGroup;
    [SerializeField] private CanvasGroup uiWinPopup;
    [SerializeField] private RCC_Camera camera;
    [SerializeField] private Transform spawnPos;
    
    
    [Inject] private DataC _dataC;
    private async void Awake()
    {
        uiControlGroup.alpha = 0;
        
        uiWinPopup.alpha = 0;
        
        FaderC.DoFadeOut(2);
        PrepareCar();

        await Task.Delay(2000);
        
        uiControlGroup.DOFade(1, 1);
    }
    

    private void PrepareCar()
    {
        var car = Instantiate(_dataC.carsObj[carIndex], spawnPos.position, spawnPos.rotation);
        camera.playerCar = car;
    }

    public void ShowWinPopup()
    {
        uiControlGroup.blocksRaycasts = false;
        uiControlGroup.DOFade(0, 1);

        uiWinPopup.DOFade(1, 1);
    }

    public async void TakeWin()
    {
        FaderC.DoFadeIn(0.5f);
        await Task.Delay(600);
        SceneManager.LoadSceneAsync("Scene_1");
    }
}
