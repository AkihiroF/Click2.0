using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public bool act = false;
    public void InputStar()
    {
        act = !act;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(act);
    }
}
