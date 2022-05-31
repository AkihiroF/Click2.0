using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInShop : MonoBehaviour
{
    public Obj obj;
    [SerializeField]private CreateData savedata;
    public Image statusicon;
    public Button button;
    public GameObject block;
    public ItemInRoom objinroom;
    [SerializeField] private TextMeshProUGUI lvltext;
    private int price = 100;
    [SerializeField] private Upmenu upmenu;
    public void UpdateStatus()
    {
        if (obj.active)
        {
            if (obj.lvl < objinroom.maxlvl)
            {
                if (savedata.data.money >= price)
                {
                    savedata.data.money -= price;
                    upmenu.UpdateInfo(savedata.data);
                    obj.stadia++;
                    lvltext.text = $"Lvl - {obj.lvl}\nPrice - {price}";
                    if (obj.stadia > 3)
                    {
                        obj.stadia = 0;
                        obj.lvl++;
                        objinroom.UpdateStatusObj();
                        lvltext.text = $"Lvl - {obj.lvl}\nPrice - {price}";
                    }
                    statusicon.sprite = obj.upgradeicon[obj.stadia];
                    price = price.GetSubsrib(obj.lvl, obj.stadia);
                }
            }
        }
        else
        {
            if(savedata.data.money >= 1200){ obj.active = true; UpdateStartStatus(); savedata.UpdateNextStat(obj); objinroom.UpdateStatusObj();}
        }
        savedata.UpdateStatusLoading(obj);
    }

    public void UpdateStartStatus()
    {
        price = price.GetSubsrib(obj.lvl, obj.stadia);
        if (obj.active){ button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade"; lvltext.text = $"Lvl - {obj.lvl}\nPrice - {price}";}
        else {lvltext.text = $"Price - 1200";}
        statusicon.sprite = obj.upgradeicon[obj.stadia];
        objinroom.UpdateStatusObj();
        if(obj.buy) Destroy(block);
    }
}
