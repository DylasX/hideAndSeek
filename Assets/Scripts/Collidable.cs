using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Collidable : MonoBehaviour
{
    // Start is called before the first frame update
    public ContactFilter2D contactFilter;
    private BoxCollider2D boxCollider;
    private Collider2D[] results = new Collider2D[10];
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        boxCollider.OverlapCollider(contactFilter, results);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i] == null)
            {
                continue;
            }
            OnCollide(results[i]);
            results[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        //Debug.Log("OnCollide was not implemented in this " + this.name);
    }
}
