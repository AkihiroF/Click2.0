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
    public void UpdateStatus()
    {
        if (obj.active)
        {
            obj.stadia++;
            if (obj.stadia > 3)
            {
                obj.stadia = 0;
                obj.lvl++;
            }
            statusicon.sprite = obj.upgradeicon[obj.stadia];
        }
        else{ obj.active = true; UpdateStartStatus(); savedata.UpdateNextStat(obj);}
        savedata.UpdateStatus(obj);
    }

    public void UpdateStartStatus()
    {
        if (obj.active) button.GetComponentInChildren<TextMeshProUGUI>().text = "Улучшить";
        statusicon.sprite = obj.upgradeicon[obj.stadia];
        if(obj.buy) Destroy(block);
    }
}
