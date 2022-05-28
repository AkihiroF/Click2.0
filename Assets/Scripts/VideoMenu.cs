using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMenu : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField]private Transform startpos, movobj;
    private bool onstart, activate;

    private void Start()
    {
        onstart = false;
        activate = false;
    }

    private void FixedUpdate()
    {
        if (activate)
        {
            if (onstart)
            {
                movobj.position = Vector3.MoveTowards(
                    movobj.position, this.gameObject.transform.position,
                    speed);
                if (movobj.position == this.gameObject.transform.position)
                {
                    activate = false;
                }
            }
            else
            {
                movobj.position = Vector3.MoveTowards(
                    movobj.position, startpos.position,
                    speed);
                if (movobj.position == startpos.position)
                {
                    activate = false;
                }
            }
        }
    }

    public void Activetemenu()
    {
        if (activate == false)
        {
            activate = !activate;
            onstart = !onstart;
        }
    }
}
