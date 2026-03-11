
using UnityEngine;
using Zenject;

public class PistolMagazine :Magazine
{
    [Inject]
    public void Construct(GManager gManager){
        this.gManager=gManager;
        gManager.pistolmagazines.Add(this);
        _magazines=gManager.pistolmagazines;
    }

}
