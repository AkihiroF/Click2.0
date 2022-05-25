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
    }

    public void UpdateStatusObj()
    {
        int ind = dataobj.lvl / srez;
        Debug.Log(ind);
        
        if(ind <= icons.Count-1)this.gameObject.GetComponent<Image>().sprite = icons[ind];
    }
}
