using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    // Start is called before the first frame update
    private Vector3 movement;
    private Animator animator;
    public bool hasAnimationsRunning = false;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        //Learn more about this, because it's more efficient to dont destroy the object and send to the ohter scene
        DontDestroyOnLoad(this);
    }

    protected virtual void Update()
    {
        //reset movementDelta and assign it to the new movement
        if (hasAnimationsRunning)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            if (movement.magnitude != 0)
            {
                //Is running
                animator.SetBool("PerformRun", true);
                animator.SetBool("PerformIdle", false);
            }
            else
            {
                animator.SetBool("PerformRun", false);
                animator.SetBool("PerformIdle", true);
            }
        }

    }

    protected virtual void UpdateMotor(Vector3 input = default(Vector3), float speed = 1.0f)
    {
        //move the player
        Vector3 currentMovement;
        if (input.magnitude > 0)
        {
            currentMovement = input;

        }
        else
        {
            currentMovement = movement;
        }

        if (currentMovement.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        //use else if instead else to avoid the player turning back again
        else if (currentMovement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //making run faster use always time delta
        transform.position += currentMovement * Time.deltaTime * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
