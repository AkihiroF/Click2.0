using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingExp : MonoBehaviour
{
    public Transform fin;
    public float speed;
    [SerializeField] private OnVideo video;
    private void FixedUpdate()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, fin.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == fin.position)
        {
            Destroy(this.gameObject);
            video.realtime += 1;
        }
    }
}
