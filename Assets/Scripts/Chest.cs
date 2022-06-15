using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    private SpriteRenderer spriteRenderer;
    public Sprite openChest;
    public GameObject[] weapons;
    private Sprite closedChest;
    private bool hint;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        closedChest = spriteRenderer.sprite;
        hint = true;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(hint && (coll.name == "mainPlayer" || coll.name == "weapon"))
        {
            Vector3 textPosition = this.transform.position;
            textPosition.y += 0.1f;
            GameManager.instance.ShowText("PRESS E", 30, Color.white,textPosition, Vector3.up, 100);
            hint = false;
        }
        if ((coll.name == "mainPlayer" || coll.name == "weapon") && Input.GetKeyDown("e") && base.collected == false)
        {
            if(spriteRenderer.sprite == closedChest)
            {
                spriteRenderer.sprite = openChest;
                //param is coin
                base.OnCollect(weapons);
            }

        }
    }

}
