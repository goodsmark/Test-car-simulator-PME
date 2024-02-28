using UnityEngine;
using Zenject;

public class Scene1ControllerInstaller : MonoInstaller
{
    [SerializeField] private Scene1Controller controller;
    public override void InstallBindings()
    {
        Container.Bind<Scene1Controller>().FromInstance(controller).AsSingle().NonLazy();
    }
}