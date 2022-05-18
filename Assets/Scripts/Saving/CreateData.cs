using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateData : MonoBehaviour
{
    public DataBase data;
    public Upmenu upmenu;
    public EnterName enterName;

    private void Start()
    {
        data = enterName.Createdatabase();
        upmenu.UpdateInfo(data);
    }
}
