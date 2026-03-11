using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SlotSaver : MonoBehaviour
{
    GManager _gManager;
    [Inject]
    public void Construct(GManager gManager){
        _gManager = gManager;
        _gManager.SetDataSaver(this);
        StartCoroutine(StartAfterFewSeconds());
    }
    void LoadSlotData(){
        SlotData data = SlotSaveSystem.Load();
        int i=0;
        foreach(Slot slot in _gManager.slots){
            if(data.blocked[i]==0){
                slot.Unlock();
            }
            i++;
        }
    }
    IEnumerator StartAfterFewSeconds(){
        yield return new WaitForSeconds(.25f);
        LoadSlotData();
    }
    public void Save(){
        SlotData data =new SlotData();
        int i=0;
        foreach(Slot slot in _gManager.slots){
            if(slot.blocked){
                data.blocked[i]=1;
            }else{
                data.blocked[i]=0;
            }
            i++;
        }
        SlotSaveSystem.Save(data);
    }
}
