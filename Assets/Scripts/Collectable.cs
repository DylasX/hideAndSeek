using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    // Start is called before the first frame update
    protected bool collected;
    public int coinsAmount;

    protected override void OnCollide(Collider2D coll)
    {
        base.OnCollide(coll);
    }


    protected void OnCollect(GameObject[] weapons = null)
    {
        collected = true;
        GameManager.instance.SaveState();
        Debug.Log(this.transform.position);
        //GameManager.instance.ShowText("PRESS E", 25, Color.black, this.transform.position, Vector3.up * 50, 2);
        if (weapons != null)
        {
            foreach (var weapon in weapons)
            {
                weapon.SetActive(true);
            }
        }
    }
}
