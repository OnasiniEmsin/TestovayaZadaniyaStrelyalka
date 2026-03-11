using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Magazine : MonoBehaviour, ICarouselle
{
    public int ammo=30;
    
    public GManager gManager;
    protected List<ICarouselle> _magazines;
    public void DestroyM(){
        _magazines.Remove(this);
        Destroy(gameObject);
    }
}
