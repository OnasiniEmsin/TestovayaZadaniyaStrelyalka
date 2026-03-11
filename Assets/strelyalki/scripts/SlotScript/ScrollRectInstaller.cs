using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScrollRectInstaller : MonoInstaller
{
    public IInventar scrollRect;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<IInventar>().FromInstance(scrollRect);
    }
}