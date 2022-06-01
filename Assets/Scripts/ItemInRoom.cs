using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemInRoom : MonoBehaviour
{
    [SerializeField] private List<Sprite> icons;
    [SerializeField] private Obj dataobj;
    public int maxlvl;
    private int srez;
    private void Start()
    {
        srez = maxlvl / icons.Count;
        this.gameObject.SetActive(dataobj.active);
    }

    public void UpdateStatusObj()
    {
        Start();
        int ind = dataobj.lvl / srez;
        this.gameObject.SetActive(dataobj.active);
        if(ind <= icons.Count-1)this.gameObject.GetComponent<Image>().sprite = icons[ind];
    }
}
