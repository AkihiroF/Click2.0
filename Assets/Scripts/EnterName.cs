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
    public DataBase data;
    [SerializeField] private CreateData createdata;
    [SerializeField] private string filename;
    [SerializeField] private TextMeshProUGUI inputfield;
    [SerializeField] private GameObject InputNameMenu;
    private void Start()
    {
        if (File.Exists(Application.dataPath + "/" + filename)){
            data = Createdatabase();
            createdata.data = data;
            createdata.EnterFile();
            Destroy(InputNameMenu);
        }
    }
    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
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
            data = new();
            data.namePlayer = nameperson;
            JsonSave.SaveToJSON<DataBase>(data, filename);
            Start();
        }
    }
    public DataBase Createdatabase()
    {
        DataBase data = JsonSave.ReadFromJSON<DataBase>(filename);
        return data;
    }
}
