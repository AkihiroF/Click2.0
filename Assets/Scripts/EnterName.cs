using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterName : MonoBehaviour
{
    private string nameperson;
    [SerializeField] private string filename;
    [SerializeField] private TextMeshProUGUI inputfield;
    [SerializeField] private GameObject InputNameMenu;
    void Awake()
    {
        nameperson = JsonSave.ReadFromJSON<DataBase>(filename).namePlayer;
        if (nameperson != null && nameperson != "")
        {
            Destroy(InputNameMenu);
        }
    }
   public void InputNameInfo()
    {
        nameperson = inputfield.text;
        if (nameperson == null && nameperson == "" && nameperson == " ")
        {
            inputfield.text = "";
        }
        else
        {
            DataBase data = new DataBase();
            data.namePlayer = nameperson;
            JsonSave.SaveToJSON<DataBase>(data, filename);
            Destroy(InputNameMenu);
        }
    }
}
