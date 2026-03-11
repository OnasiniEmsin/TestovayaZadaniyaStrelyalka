using UnityEngine;
using Zenject;

public class ExampleUsage : MonoBehaviour
{
    PlayerData data;
    GManager _gManager;
    [Inject]
    public void Construct(GManager gManager)
    {
        _gManager=gManager;
        
        data = SaveSystem.Load();

        Debug.Log("Money: " + data.money);

        _gManager._money=data.money;

        _gManager.eusage=this;
    }

    public void AddMoney(int amount)
    {
        data.money += amount;

        SaveSystem.Save(data);
    }

    public void SaveMoneyData(){
        PlayerData pdata=new();
        pdata.money=_gManager._money;
        SaveSystem.Save(pdata);
    }

    
}