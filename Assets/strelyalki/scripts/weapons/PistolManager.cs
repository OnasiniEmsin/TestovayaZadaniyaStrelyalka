using Zenject;
using UnityEngine;

public class PistolManager:MonoBehaviour 
{
    pistol _pistol;
    GManager _gManager;
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
    }
    public void Fire(){
        if(_pistol==null){
            getGun();
        }else{
            _pistol.Fire();
        }
    }
    void getGun(){
        if(_gManager.pistols.Count!=0){
            Debug.Log(_gManager.pistols.Count);
            foreach(pistol p in _gManager.pistols){
                _pistol=p;
                break;
            }
            Fire();
        }else{
            Debug.Log("такая оружия не айдено");
        }
    }
}
