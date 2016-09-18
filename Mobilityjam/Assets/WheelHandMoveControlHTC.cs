using UnityEngine;
using System.Collections;
using System;

public class WheelHandMoveControlHTC : WheelHandMovementController
{
    public WandController _htcWandController;
    public override bool IshandGrabing()
    {
        return _htcWandController.triggerPress;
    }

    public override bool IshandGrabingDown()
    {
        return _htcWandController.triggerDown;
    }

    public override bool IshandGrabingUp()
    {
        return _htcWandController.triggerUp;
    }
}