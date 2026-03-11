using Zenject;
using UnityEngine;

public class GunMagazine :MonoBehaviour, ICarouselle
{
    public int ammo=30;
    [Inject]
    public void Construct(GManager gManager){
        this.gManager=gManager;
        gManager.gunmagazines.Add(this);
    }
    public GManager gManager;
    public void DestroyM(){
        gManager.gunmagazines.Remove(this);
        Destroy(gameObject);
    }
}
