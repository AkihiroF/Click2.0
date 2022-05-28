using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateData : MonoBehaviour
{
    public Upmenu upmenu;
    public string filename;
    public string filenameobj;
    public DataBase data;
    public List<ItemInShop> Objinshop;
    public List<Obj> objects;
    public List<ObjSave> savingobject;
    public ViborTheme viborTheme;
    public void EnterFile()
    {
        
        savingobject = JsonSave.ReadListFromJSON<ObjSave>(filenameobj);
        upmenu.UpdateInfo(data);
        UpdateStatusLoading();
    }

    public void UpdateStatusLoading(Obj obj)
    {
        for (int i = 0; i < Objinshop.Count; i++)
        {
            if (objects[i].id == obj.id)
            {
                objects[i] = obj;
            }
        }
        UpdateStatusSaving();
        JsonSave.SaveToJSON(savingobject,filenameobj);
    }

    public void UpdateStatusCreatVideo(int sub, int mon, bool active, float realtime, int predsub, int predmon)
    {
        data.subscribers = sub;
        data.active = active;
        data.money = mon;
        data.realtime = realtime;
        data.predmon = predmon;
        data.predsub = predsub;
        JsonSave.SaveToJSON(data, filename);
    }
    public void UpdateStatusLoading()
    {
        for (int i = 0; i < Objinshop.Count; i++)
        {
            if (savingobject.Count != 0)
            {
                objects[i].active = savingobject[i].active;
                objects[i].buy = savingobject[i].active;
                objects[i].lvl = savingobject[i].lvl;
                objects[i].stadia = savingobject[i].stadia;
                UpdateNextStat(objects[i]);
            }
            Objinshop[i].obj = objects[i];
            Objinshop[i].UpdateStartStatus();
            Objinshop[i].objinroom.UpdateStatusObj();
        }
        viborTheme.UPdateStatus(data.subscribers, data.money, data.active, data.realtime, data.predsub, data.predmon);
    }

    public void UpdateStatusSaving()
    {
        savingobject.Clear();
        for (int i = 0; i < objects.Count; i++)
        {
            ObjSave save = new();
            save.active = objects[i].active;
            save.buy = objects[i].buy;
            save.lvl = objects[i].lvl;
            save.stadia = objects[i].stadia;
            savingobject.Add(save);
        }
    }

    public void UpdateNextStat(Obj obj)
    {
        for (int i = 0; i < Objinshop.Count-1; i++)
        {
            if (Objinshop[i].obj.active)
            {
                Objinshop[i + 1].obj.buy = true;
                Objinshop[i + 1].UpdateStartStatus();
            }
        }
    }
}
