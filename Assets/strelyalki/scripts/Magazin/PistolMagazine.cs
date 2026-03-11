
using UnityEngine;
using Zenject;

public class PistolMagazine :MonoBehaviour, ICarouselle
{
    public int ammo=15;
    [Inject]
    public void Construct(GManager gManager){
        this.gManager=gManager;
        gManager.pistolmagazines.Add(this);
    }
    
    public GManager gManager;
    public void DestroyM(){
        
    }
}
