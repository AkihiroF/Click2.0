using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NextTutorial : MonoBehaviour, IPointerClickHandler
{
    public Tutorialscr next;
    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
            next.NextPage();
        }
    }
}
