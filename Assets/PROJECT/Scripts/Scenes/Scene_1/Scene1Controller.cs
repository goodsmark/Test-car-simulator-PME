using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Scene1Controller : MonoBehaviour
{
    public CarSelector CarSelector;
    public Scene1CameraSettings CameraSettings;
    
    public Action<int> OnCarChanged;

    private void Start()
    {
        CarSelector.Init(CameraSettings.carPositionSpawn.position);
        FaderC.DoFadeOut(2);
    }


    public async void StartRace()
    {
        FaderC.DoFadeIn(0.5f);
        await Task.Delay(600);
        SceneManager.LoadSceneAsync("Scene_2");
    }
}
