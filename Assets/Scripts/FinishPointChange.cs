using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPointChange : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private RectTransform point;
    public float _value;


    void Update()
    {
        _value = bar.fillAmount;
        ChangePoint(_value);
    }

    void ChangePoint(float value)
    {
        float amount = value*1132;
        
        point.localPosition = new Vector3(amount,0,0);
    }
}
