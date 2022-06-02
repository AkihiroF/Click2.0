using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using System.IO;

public class Comment : MonoBehaviour
{
    [SerializeField]private List<string> sourses;
    private List<List<string>> comment = new();
    [SerializeField] private GameObject osnova, position;
    [SerializeField] private CreateData data;
    [Header("Setings comment")]
    [SerializeField] private int items;
    public void StartComment(int osnovacomm)
    {
        for (int i = 0; i < sourses.Count; i++)
        {
            comment.Add(ReadComFromFile(sourses[i]));
        }

        foreach (Transform child in position.transform)
        {
            Destroy(child.gameObject);
        }
        {
            for (int i = 0; i < position.transform.childCount; i++)
            {
                Destroy(position.transform.GetChild(i));
            }
        }
        InputComm(osnovacomm);
    }

    private void InputComm(int thema)
    {
        List<string> outputcomm = new List<string>();
        for (int i = 0; i < items; i++)
        {
            if (i <= 2)
            {
                outputcomm.Add(comment[thema][Random.Range(1, comment[thema].Count)]);
            }
            else
            {
                outputcomm.Add(comment[Random.Range(1,sourses.Count)][Random.Range(1,4)]);
            }
        }

        for (int i = 0; i < items; i++)
        {
            CreateCommBody(outputcomm[Random.Range(1, outputcomm.Count)]);
        }
    }

    private List<string> ReadComFromFile(string source)
    {
        string startcomm = JsonSave.ReadFile(Path.Combine(Application.streamingAssetsPath, source));
        string[] arraycomm = startcomm.Split('\n');
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
        clone.localScale = new Vector3(1, 1, 1);
        clone.gameObject.SetActive(true);
    }
}
