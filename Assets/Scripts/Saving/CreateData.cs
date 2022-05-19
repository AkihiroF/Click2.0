using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateData : MonoBehaviour
{
    public Upmenu upmenu;
    public string filename;
    public string filenameobj;
    public DataBase data;
    public List<ItemInShop> Objinshop;
    public List<Obj> objects;

    public void EnterFile()
    {
        objects = JsonSave.ReadListFromJSON<Obj>(filenameobj);
        upmenu.UpdateInfo(data);
        UpdateStatus();
    }

    public void UpdateStatus(Obj obj)
    {
        for (int i = 0; i < Objinshop.Count; i++)
        {
            if (objects[i] == obj)
            {
                objects[i] = obj;
            }
        }
        JsonSave.SaveToJSON(objects,filenameobj);
    }

    public void UpdateStatus()
    {
        for (int i = 0; i < Objinshop.Count; i++)
        {
            Objinshop[i].obj = objects[i];
            Objinshop[i].UpdateStartStatus();
        }
    }

    public void UpdateNextStat(Obj obj)
    {
        for (int i = 0; i < Objinshop.Count-1; i++)
        {
            if (Objinshop[i].obj == obj)
            {
                Objinshop[i + 1].obj.buy = true;
                Objinshop[i + 1].UpdateStartStatus();
            }
        }
    }
}
