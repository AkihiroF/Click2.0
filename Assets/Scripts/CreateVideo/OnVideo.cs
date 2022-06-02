using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnVideo : MonoBehaviour
{
    public float time, realtime;
    public TextMeshProUGUI timetext;
    public Image status;
    public ViborTheme vibor;
    public CreateData data;
    
    private void FixedUpdate()
    {
        realtime += Time.deltaTime;
        double tt = Math.Ceiling(time - realtime);
        timetext.text = $"{tt}";
        data.data.realtime = realtime;
        status.fillAmount = realtime / time;
        JsonSave.SaveToJSON(data.data, data.filename);
        if (realtime >= time)
        {
            vibor.DeleteVid();
            time = 0;
            realtime = 0;
            status.fillAmount = 0;
            this.gameObject.SetActive(false);
        }

    }
}
