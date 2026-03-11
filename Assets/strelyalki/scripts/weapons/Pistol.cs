using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class pistol : Weapon
{
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
        _gManager.pistols.Add(this);
        _magazines=gManager.pistolmagazines;
    }
    protected override void printReloaded(){
        Debug.Log("Пистолет перезаряжено");
    }
    protected override void printNotFound(){
        Debug.Log("Патроны пистолета не остались");
    }
    protected override void printFiring(){
        Debug.Log("стрелять через пистолет");
    }
}
