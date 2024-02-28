using UnityEngine;
using Zenject;

public class Scene2ControllerInstaller : MonoInstaller
{
    [SerializeField] private Scene2Controller controller;
    public override void InstallBindings()
    {
        Container.Bind<Scene2Controller>().FromInstance(controller).AsSingle().NonLazy();
    }
}