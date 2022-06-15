using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> textList = new List<FloatingText>();
    private void Update()
    {
        foreach (FloatingText text in textList) 
            text.UpdateFloatingText();
    }
    public void Show (string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        //remember screen coordinates
        floatingText.text.transform.position = Camera.main.WorldToScreenPoint(position); //Transfer world space to screen space so we can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();

    }
    private FloatingText GetFloatingText()
    {
        FloatingText txt = textList.Find(t => !t.active);
        if (txt == null)
        {
            txt = new FloatingText();
            txt.text = Instantiate(textPrefab);
            txt.text.transform.SetParent(textContainer.transform);
            txt.txt = txt.text.GetComponent<Text>();

            textList.Add(txt);
        }
        return txt;
    }
}
