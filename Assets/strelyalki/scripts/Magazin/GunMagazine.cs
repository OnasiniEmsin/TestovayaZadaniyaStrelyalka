using Zenject;
using UnityEngine;

public class GunMagazine :Magazine
{
    [Inject]
    public void Construct(GManager gManager){
        this.gManager=gManager;
        gManager.gunmagazines.Add(this);
        _magazines=gManager.gunmagazines;
    }
}
