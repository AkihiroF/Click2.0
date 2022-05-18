using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class EnterName : MonoBehaviour, IPointerClickHandler
{
    private string nameperson;
    DataBase data;
    [SerializeField] private string filename;
    [SerializeField] private TextMeshProUGUI inputfield;
    [SerializeField] private GameObject InputNameMenu;
    private void Awake()
    {
        if (File.Exists(filename) == false){
            Destroy(InputNameMenu);
        }
    }
    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
            data = Createdatabase();
            InputNameInfo();
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
            data.namePlayer = nameperson;
            JsonSave.SaveToJSON<DataBase>(data, filename);
            Destroy(InputNameMenu);
        }
    }
    public DataBase Createdatabase()
    {
        DataBase data = JsonSave.ReadFromJSON<DataBase>(filename);
        return data;
    }
}
