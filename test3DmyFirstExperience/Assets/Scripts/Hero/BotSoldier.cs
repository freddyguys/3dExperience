using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(ISoldierController))]
class BotSoldier : MonoBehaviour, ISoldier
{
    private float health = 100f;
    private float speed = 0.1f;
    private TeamTag teamTag;
    [SerializeField]
    private Rigidbody rBody;
    private ISoldierController controller;

    private void Awake()
    {
        controller = GetComponent<ISoldierController>();
    }

    private void Update()
    {
        ControlCommands commandsLast = controller.GetControl();
        var normalizedDirection =  commandsLast.moveDirection.normalized;
        transform.position += normalizedDirection * speed;
        transform.Rotate(commandsLast.rotateDelta);
    }

    #region ISoldier realisation
    public float Health { get { return health; } }

    public Transform MainTransform { get { return transform; } }

    public TeamTag Tag { get { return teamTag; } }

    public void DealDamage(RaycastHit hitInfo, float damage, float impactForce)
    {
        health -= damage;
        if (health <= 0f) { /*kill method*/}
        rBody.AddForce(-hitInfo.normal * impactForce);
    }

    public void Spawn(Vector3 pos, TeamTag tag)
    {
        transform.position = pos;
        this.teamTag = tag;
    }
    #endregion
}

