using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISoldierController
{
    ControlCommands GetControl();
}

struct ControlCommands
{
    public Vector3 moveDirection, rotateDelta;
}
