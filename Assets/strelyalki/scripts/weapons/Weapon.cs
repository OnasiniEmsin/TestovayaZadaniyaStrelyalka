using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour,IWeapon
{
    public GManager _gManager;
    public Magazine _gunMagazine;
    protected List<ICarouselle> _magazines;
    protected int bullets=0;

    public void Fire(){
        if(bullets<=0){
            reload();
        }else{
            bullets--;
            printFiring();
            Debug.Log($"Патроны {bullets}");
        }
    }
    void reload(){
        GetMagazine();
    }
    void GetMagazine(){
        if(_gManager.gunmagazines.Count>0){
            foreach(Magazine magazine in _magazines){
                _gunMagazine=magazine;
                _magazines.Remove(magazine);
                bullets=_gunMagazine.ammo;
                printReloaded();
                break;
            }
        }else{
            printNotFound();
        }
    }
    protected virtual void printReloaded(){
        Debug.Log("Автомат перезаряжено");
    }
    protected virtual void printNotFound(){
        Debug.Log("Патроны не остались");
    }
    protected virtual void printFiring(){
        Debug.Log("стрелять через автомат");
    }
}
