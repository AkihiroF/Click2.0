using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upmenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playername, subscribers, money, moneyinshop;
    public void UpdateInfo(DataBase data)
    {
        playername.text = data.namePlayer;
        subscribers.text = "" + data.subscribers;
        money.text = "" + data.money;
        moneyinshop.text = "" + data.money;
    }
}
