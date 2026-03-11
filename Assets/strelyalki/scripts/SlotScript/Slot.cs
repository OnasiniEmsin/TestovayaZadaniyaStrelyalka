using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    [Inject]
    public void Construct(GManager gManager)
    {
        _gManager = gManager;
        setSelfToSlotArray();
    }
    public GManager _gManager;
    public bool blocked=true;

    public GameObject unlockButton;


    void setSelfToSlotArray()
    {
        _gManager.slots[_gManager.slotNumber] = this;
        _gManager.slotNumber++;
    }

    public void OnDrop(PointerEventData pedata)
    {
        if(blocked){
            return;
        }
        if(pedata.pointerDrag.tag!="Item"){
            return;
        }
        if (pedata != null)
        {
            pedata.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            pedata.pointerDrag.GetComponent<DragAndDrop>().myPosition=transform;
        }
    }

    public void Unlock(){
        unlockButton.active=false;
        blocked=false;
    }
    public void Buy(){
        if(_gManager.IsHaveMoney(3000)){
            Unlock();
            _gManager.BuySlot();
        }
    }
    
}
