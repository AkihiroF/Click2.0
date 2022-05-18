using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateData : MonoBehaviour
{
    public Upmenu upmenu;
    public EnterName enterName;
    public DataBase data;

    public void EnterFile()
    {
        upmenu.UpdateInfo(data);
    }
}
