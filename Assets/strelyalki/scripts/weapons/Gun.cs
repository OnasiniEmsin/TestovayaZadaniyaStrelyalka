
using UnityEngine;
using Zenject;

public class Gun : MonoBehaviour,IWeapon
{
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
        _gManager.guns.Add(this);
    }
    
    public GManager _gManager;
    public GunMagazine _gunMagazine;
    int bullets=0;

    public void Fire(){
        if(bullets<=0){
            reload();
        }else{
            bullets--;
            Debug.Log("стрелять через автомат");
            Debug.Log($"Патроны {bullets}");
        }
    }
    void reload(){
        GetMagazine();
    }
    void GetMagazine(){
        if(_gManager.gunmagazines.Count>0){
            foreach(GunMagazine magazine in _gManager.gunmagazines){
                _gunMagazine=magazine;
                _gManager.gunmagazines.Remove(magazine);
                bullets=_gunMagazine.ammo;
                Debug.Log("Автомат перезаряжено");
                break;
            }
        }else{
            Debug.Log("Патроны не остались");
        }
    }
}
