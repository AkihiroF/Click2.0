using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Comment : MonoBehaviour
{
    [SerializeField]private List<string> sourses;
    private List<List<string>> comment = new();
    [SerializeField] private GameObject osnova, position;
    public string osnovacomm;
    [SerializeField] private CreateData data;
    [Header("Setings comment")]
    [SerializeField] private int items;
    public void StartComment()
    {
        for (int i = 0; i < sourses.Count; i++)
        {
            comment.Add(ReadComFromFile(sourses[i]));
        }

        for (int i = 0; i < sourses.Count; i++)
        {
            if (comment[i][0] == osnovacomm)
            {
                InputComm(i);
            }
        }
    }

    private void InputComm(int thema)
    {
        List<string> outputcomm = new List<string>();
        for (int i = 0; i < items; i++)
        {
            if (i <= 2)
            {
                outputcomm.Add(comment[thema][Random.Range(1, comment[thema].Count)]);
                Debug.Log(outputcomm[i]);
            }
            else
            {
                outputcomm.Add(comment[Random.Range(0,sourses.Count)][Random.Range(1,10)]);
            }
        }

        for (int i = 0; i < items; i++)
        {
            CreateCommBody(outputcomm[Random.Range(0, outputcomm.Count)]);
        }
    }

    private List<string> ReadComFromFile(string source)
    {
        string startcomm = JsonSave.ReadFile(JsonSave.GetPath(source));
        string[] arraycomm = startcomm.Split('.');
        List<string> list = new List<string>();
        for (int i = 0; i < arraycomm.Length; i++)
        {
            arraycomm[i] = arraycomm[i].Replace("[]", $"{data.data.namePlayer}");
            list.Add(arraycomm[i]);
        }
        return list;
    }

    private void CreateCommBody(string text)
    {
        Transform clone = Instantiate(osnova).transform;
        clone.SetParent(position.transform);
        clone.GetComponentInChildren<TextMeshProUGUI>().text = text;
        clone.gameObject.SetActive(true);
    }
}
