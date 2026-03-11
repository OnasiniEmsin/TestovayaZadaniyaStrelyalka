using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class pistol : MonoBehaviour,IWeapon
{
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
        _gManager.pistols.Add(this);
    }
    
    public GManager _gManager;
    public PistolMagazine _pistolMagazine;
    int bullets=0;

    public void Fire(){
        if(bullets<=0){
            reload();
        }else{
            bullets--;
            Debug.Log("стрелять через пистолет");
            Debug.Log($"Патроны {bullets}");
        }
    }
    void reload(){
        GetMagazine();
    }
    void GetMagazine(){
        if(_gManager.pistolmagazines.Count>0){
            foreach(PistolMagazine magazine in _gManager.pistolmagazines){
                _pistolMagazine=magazine;
                _gManager.pistolmagazines.Remove(magazine);
                bullets=_pistolMagazine.ammo;
                Debug.Log("Пистолет перезаряжено");
                break;
            }
        }else{
            Debug.Log("Патроны не остались");
        }
    }
}
