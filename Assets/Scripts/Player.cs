using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private void FixedUpdate()
    {
        UpdateMotor();
    }

}
