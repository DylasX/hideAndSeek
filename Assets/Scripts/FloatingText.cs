using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FloatingText
{
    // Start is called before the first frame update
    public bool active;
    public GameObject text;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
        active = true;
        lastShown = Time.time;
        text.SetActive(active);
    }

    public void Hide()
    {
        active=false; 
        text.SetActive(active);
    }

    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if(Time.time-lastShown > duration || Input.GetKeyDown("e"))
        {
            Hide();
        }

        text.transform.position += motion * Time.deltaTime;
    }


}
