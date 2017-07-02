using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

class EnemyController : MonoBehaviour
{
    public int Ammunition { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Range { get; set; }
    public Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        Health = 100f;
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        agent.destination = target.position;
    }

    public void Fight()
    {
        throw new NotImplementedException();
    }

    public void Spawn()
    {
        throw new NotImplementedException();
    }

    public void Shoot()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) Death();
        print("health: " + Health);
    }

    public void Death()
    {
        print("destroy");
        Destroy(gameObject, 1f);
    }
}

