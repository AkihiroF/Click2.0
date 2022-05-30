using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class ButtOn : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject ex;
    [SerializeField] private Transform finish, spawn;
    [SerializeField] private float speed;
    [SerializeField] private ViborTheme video;

    public void OnPointerClick(PointerEventData a)
    {
        if (a.button == PointerEventData.InputButton.Left)
        {
            if (video.active)
            {
                CreateEx();
            }
        }
    }
    private void CreateEx()
    {
        Transform body = Instantiate(ex).transform;
        body.position = Input.mousePosition;
        body.transform.SetParent(spawn);
        body.GetComponent<MovingExp>().fin = finish;
        body.GetComponent<MovingExp>().speed = speed;
        body.gameObject.SetActive(true);
    }
}
