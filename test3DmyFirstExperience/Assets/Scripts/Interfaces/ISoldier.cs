using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

interface ISoldier
{
    float Health { get; }
    TeamTag Tag { get; }
    Transform MainTransform { get; }
    void Spawn(Vector3 pos, TeamTag tag);
    void DealDamage(RaycastHit hitinfo, float damage, float impactForce);
}

enum TeamTag
{ none, Alfa, Bravo }

