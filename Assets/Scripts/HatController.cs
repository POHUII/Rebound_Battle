using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : PlayerMovement
{
    protected override void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal_1");
        inputVertical = Input.GetAxisRaw("Vertical_1");
    }
}
