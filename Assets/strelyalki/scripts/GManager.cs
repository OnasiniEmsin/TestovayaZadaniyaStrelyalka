
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public Slot[] slots;

    SlotSaver _slotSaver;

    [HideInInspector] public int slotNumber = 0;

    public int _money=10000;

    public List <ICarouselle> pistolmagazines=new(),gunmagazines=new();

    public List <IWeapon> pistols=new(),guns=new();
    
    public ExampleUsage eusage;

    
    public void BuySlot(){
        _slotSaver.Save();
    }
    
    public void SetDataSaver(SlotSaver ssaver){
        _slotSaver=ssaver;
    }
    public bool IsHaveMoney(int i){
        if(i<=_money){
            _money-=i;
            eusage.SaveMoneyData();
            Debug.Log("имущество куплено");
            return true;
        }
        return false;
    }
}
