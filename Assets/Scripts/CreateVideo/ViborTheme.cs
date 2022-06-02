using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


public class ViborTheme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subsTex, moneyTex;
    private int subscribers, money;
    private bool active;
    private int predvsub, predvmon;
    [SerializeField]private CreateData data;
    [SerializeField] private VideoMenu menu;
    private List<Statt> time = new List<Statt>();
    private string namefile = "stat.json";
    [SerializeField] private Comment coments;
    private int toptema;
    [SerializeField]private List<Star> xtwo;
    [Header("Rooms")]
    [SerializeField] private List<GameObject> backgrounds;


    private void Start()
    {
        if (File.Exists(JsonSave.GetPath(namefile)))
        {
            time = JsonSave.ReadListFromJSON<Statt>(namefile);
        }
        else
        {
            for (int i = 0; i < backgrounds.Count; i++)
            {
                Statt st = new Statt();
                st.stt = 0;
                st.time = 10;
                time.Add(st);
            }
            JsonSave.SaveToJSON(time, namefile);
        }
    }

    public void UPdateStatus(int sub, int mon, int predsub, int predmon)
    {
        subscribers = sub;
        money = mon;
        subsTex.text = "" + subscribers;
        moneyTex.text = "" + money;
        this.predvmon = predmon;
        this.predvsub = predsub;
        data.UpdateStatusCreatVideo(subscribers,money,predvsub,predvmon);
        
    }

    
    public void CreateVideo(int i)
    {
        if (active == false)
        {
            menu.Activetemenu();
            time[i].stt++;
            time[i].time = time[i].time.GetTime(data.objects[1].lvl);
            CreateScene(backgrounds[i],time[i].time);
            coments.StartComment(i);
            switch (i)
            {
                case 0:
                    if (toptema == i)
                    {
                        predvmon = money.GetMoney(subscribers) * 2;
                        predvsub = subscribers.GetSubsrib(data.objects[2].lvl, data.objects[3].lvl) * 2;
                    }
                    else
                    {
                        predvmon = money.GetMoney(subscribers);
                        predvsub = subscribers.GetSubsrib(data.objects[2].lvl, data.objects[3].lvl);
                    }
                    active = true;
                    data.UpdateStatusCreatVideo(subscribers, money, predvsub, predvmon);
                    break;
                case 1:
                    if (toptema == i)
                    {
                        predvmon = money.GetMoney(subscribers) * 2;
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl) * 2;
                    }
                    else
                    {
                        predvmon = money.GetMoney(subscribers);
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl);
                    }
                    active = true;
                    data.UpdateStatusCreatVideo(subscribers, money, predvsub, predvmon);
                    break;
                case 2:
                    if (toptema == i)
                    {
                        predvmon = money.GetMoney(subscribers) * 2;
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl) * 2;
                    }
                    else
                    {
                        predvmon = money.GetMoney(subscribers);
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl);
                    }
                    active = true;
                    data.UpdateStatusCreatVideo(subscribers, money, predvsub, predvmon);
                    break;
                case 3:
                    if (toptema == i)
                    {
                        predvmon = money.GetMoney(subscribers) * 2;
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl) * 2;
                    }
                    else
                    {
                        predvmon = money.GetMoney(subscribers);
                        predvsub = subscribers.GetSubsrib(data.objects[3].lvl, data.objects[4].lvl);
                    }
                    active = true;
                    data.UpdateStatusCreatVideo(subscribers, money, predvsub, predvmon);
                    break;
            }
            if (xtwo[toptema].act) xtwo[toptema].InputStar();
            toptema = toptema.GetToptem();
            xtwo[toptema].InputStar();
            Debug.Log(toptema);
        }
    }

    public void DeleteVid()
    {
        subscribers = predvsub;
        money = predvmon;
        active = false;
        JsonSave.SaveToJSON(time,namefile);
        UPdateStatus(subscribers, money,predvsub,predvmon);
    }

    private void CreateScene(GameObject body,float time)
    {
        body.GetComponent<OnVideo>().time = time;
        body.SetActive(true);
    }
}
[Serializable]
public class Statt
{
    public float time;
    public int stt;
}
