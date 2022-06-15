using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : Collidable
{
    // Start is called before the first frame update
    public Dialog dialog;
    public bool isActiveDialog;

    protected override void Start()
    {
        base.Start();
        isActiveDialog = false;
    }
    public void TriggerDialogue()
    {
        Debug.Log(FindObjectOfType<DialogManager>());
        FindObjectOfType<DialogManager>().StartDialogue(dialog);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "mainPlayer" && Input.GetKeyDown("e") && !isActiveDialog )
        {
            TriggerDialogue();
            isActiveDialog = true;
        }
    }
}
