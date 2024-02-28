using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DataCInstaller", menuName = "Installers/DataCInstaller")]
public class DataCInstaller : ScriptableObjectInstaller<DataCInstaller>
{
    [SerializeField] private DataC dataC;
    public override void InstallBindings()
    {
        Container.Bind<DataC>().FromInstance(dataC).AsSingle().NonLazy();
    }
}