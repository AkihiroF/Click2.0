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
    public void UpdateStatus()
    {
        if (obj.active)
        {
            if (obj.lvl < objinroom.maxlvl)
            {
                obj.stadia++;
                if (obj.stadia > 3)
                {
                    obj.stadia = 0;
                    obj.lvl++;
                    objinroom.UpdateStatusObj();
                }
                statusicon.sprite = obj.upgradeicon[obj.stadia];
            }
        }
        else{ obj.active = true; UpdateStartStatus(); savedata.UpdateNextStat(obj); objinroom.UpdateStatusObj();}
        savedata.UpdateStatusLoading(obj);
    }

    public void UpdateStartStatus()
    {
        if (obj.active) button.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade";
        statusicon.sprite = obj.upgradeicon[obj.stadia];
        objinroom.UpdateStatusObj();
        if(obj.buy) Destroy(block);
    }
}
