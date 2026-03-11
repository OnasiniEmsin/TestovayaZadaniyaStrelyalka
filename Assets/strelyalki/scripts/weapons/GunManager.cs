using Zenject;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    Gun _gun;
    GManager _gManager;
    [Inject]
    public void Construct(GManager gManager){
        _gManager=gManager;
    }
    public void Fire(){
        if(_gun==null){
            getGun();
        }else{
            _gun.Fire();
        }
    }
    void getGun(){
        if(_gManager.guns.Count!=0){
            foreach(Gun g in _gManager.guns){
                _gun=g;
                break;
            }
            Fire();
        }else{
            Debug.Log("такая оружия не айдено");
        }
    }
}
