using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject bodyMenu;
    public bool active;
    [SerializeField] private bool dele;
    [SerializeField] private Music music;

    private void Start()
    {
        StatusMenu();
    }
    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
            ActiveMenu();
        }
    }
    public void ActiveMenu()
    {
        active = !active;
        StatusMenu();
        music.StartPlayMusic(0);
        if (dele)
        {
            Destroy(bodyMenu);
        }
    }
    private void StatusMenu()
    {
        bodyMenu.SetActive(active);
    }
}
