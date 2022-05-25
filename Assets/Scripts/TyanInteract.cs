using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TyanInteract : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private double time,rt;
    [SerializeField] private List<Sprite> icons;
    [SerializeField] private GameObject like;
    private bool click = false;
    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
            rt = time;
            click = true;
        }
    }

    private void FixedUpdate()
    {
        if (click)
        {
            this.gameObject.GetComponent<Image>().sprite = icons[1];
            like.SetActive(true);
            rt -= Time.deltaTime;
            if (rt <= 0)
            {
                click = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = icons[0];
            like.SetActive(false);
        }
    }
}
