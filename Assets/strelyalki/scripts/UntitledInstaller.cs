using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    public GManager GameManagerPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GManager>().FromInstance(GameManagerPrefab);
    }
}