using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    // Start is called before the first frame update
    [TextArea(3,10)]
    public string[] sentences;
    public string name;
}
