
using UnityEngine;
using Zenject;

public class Gun : Weapon
{
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
        _gManager.guns.Add(this);
        _magazines=gManager.gunmagazines;
    }
}
