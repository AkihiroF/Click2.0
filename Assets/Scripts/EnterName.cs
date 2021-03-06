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
    [SerializeField] private List<Obj> startObj;
    public Tutorialscr tut;
    private char[] chars = {'й','ц','у','к','е','н','г','ш','щ','з','х','ъ','ф','ы','в','а','п','р','о','л','д','ж',
        'э','я','ч','с','м','и','т','ь','б','ю','ё'};
    private void Start()
    {
        if (File.Exists(JsonSave.GetPath(filename))){
            data = Createdatabase();
            createdata.filename = filename;
            createdata.data = data;
            createdata.objects = startObj;
            createdata.EnterFile();
            if (createdata.data.tutorial)
            {
                for (int i = 0; i < tut.tutorobj.Count; i++)
                {
                    tut.NextPage();
                }
            }
            else
            {
                tut.NextPage();
                tut.NextPage();
            }
            Destroy(InputNameMenu);
        }
        else tut.NextPage();
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
        if (nameperson.Length < 3)
        {
            inputfield.text = "";
        }
        else
        {
            bool norm = true;
            string prov = nameperson.ToLower();
            for (int i = 0; i < chars.Length; i++)
            {
                if (prov.Contains(chars[i]))
                {
                    inputfield.text = "";
                    norm = false;
                    break;
                }
            }

            if (norm)
            {
                data = new();
                data.namePlayer = nameperson;
                JsonSave.SaveToJSON<DataBase>(data, filename);
                createdata.filename = filename;
                createdata.data = data;
                createdata.objects = startObj;
                createdata.EnterFile();
                Destroy(InputNameMenu);
            }
        }
    }
    public DataBase Createdatabase()
    {
        
        DataBase data = JsonSave.ReadFromJSON<DataBase>(filename);
        return data;
    }
}
