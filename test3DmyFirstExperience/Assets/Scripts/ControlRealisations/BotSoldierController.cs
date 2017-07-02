using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class BotSoldierController : MonoBehaviour, ISoldierController
{
    ControlCommands commands = new ControlCommands();

    public ControlCommands GetControl()
    {
        return commands;
    }

    private void Awake()
    {
        StartCoroutine(CicleMoves());
        commands.rotateDelta = new Vector3(0f, 1f, 0f);
    }

    IEnumerator CicleMoves()
    {
        bool isForward = false;
        for (;;)
        {
            commands.moveDirection = new Vector3(0.01f * (isForward ? 1f : -1f), 0f, 0f);
            isForward ^= true;
            yield return new WaitForSeconds(2f);
        }
    }
}

