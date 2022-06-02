using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMenu : MonoBehaviour
{
    private bool active;
    [SerializeField] private GameObject obj;

    private void Start()
    {
        active = true;
        Activetemenu();
    }

    
    public void Activetemenu()
    {
        active = !active;
        obj.SetActive(active);
    }
}
