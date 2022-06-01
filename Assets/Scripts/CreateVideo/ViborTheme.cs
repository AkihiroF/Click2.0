using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ViborTheme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subsTex, moneyTex, timetext;
    public int subscribers, money;
    public float time = 10, realtime;
    public bool active = false;
    public Image status;
    private int predvsub, predvmon;
    [SerializeField] private GameObject obrazec;
    [SerializeField]private CreateData data;
    [SerializeField] private VideoMenu menu;

    public void UPdateStatus(int sub, int mon, bool active, float realtime, int predsub, int predmon)
    {
        time = time.GetTime(data.objects[2].lvl);
        subscribers = sub;
        money = mon;
        subsTex.text = "" + subscribers;
        moneyTex.text = "" + money;
        this.active = active;
        this.realtime = realtime;
        this.predvmon = predmon;
        this.predvsub = predsub;
        data.UpdateStatusCreatVideo(subscribers,money,active,realtime,predvsub,predvmon);
    }

    
    public void CreateVideo(int i)
    {
        if (active == false)
        {
            realtime = 0;
            menu.Activetemenu();
            switch (i)
            {
                case 0:
                    if (data.data.toptema == i)
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
                    data.UpdateStatusCreatVideo(subscribers, money, active, realtime, predvsub, predvmon);
                    break;
                case 1:
                    if (data.data.toptema == i)
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
                    data.UpdateStatusCreatVideo(subscribers, money, active, realtime, predvsub, predvmon);
                    break;
                case 2:
                    if (data.data.toptema == i)
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
                    data.UpdateStatusCreatVideo(subscribers, money, active, realtime, predvsub, predvmon);
                    break;
                case 3:
                    if (data.data.toptema == i)
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
                    data.UpdateStatusCreatVideo(subscribers, money, active, realtime, predvsub, predvmon);
                    break;
            }
        }
    }

    public void DeleteVid()
    {
        subscribers = predvsub;
        money = predvmon;
        UPdateStatus(subscribers, money,active,realtime,predvsub,predvmon);
    }

    private void CreateScene(Sprite back)
    {
        
    }
}
