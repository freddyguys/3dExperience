using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    
    private float speed = 7f;
    Animator animator;
    //public Camera cam;
    //public Gun gunScript;
    float fireRate = 15;
    float nextTimeToFire = 0f;
    float impactForce = 50f;


    public int Ammunition { get; set; }
    public float Health { get; set; }
    public float Damage { get; set; }
    public float Range { get; set; }

    
    Rigidbody rBody;
    float forwardInput, turnInput;

  

    private void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Spawn();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        //if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        //{
        //    nextTimeToFire = Time.time + 1f / fireRate;
        //    Shoot();
        //}

        GetInput();

    }

    public void Spawn()
    {
        transform.Translate(turnInput * Time.deltaTime * speed/1.5f, 0f, forwardInput * Time.deltaTime * speed);
        if (turnInput != 0 || forwardInput != 0f)
        { animator.SetBool("isRuning", true); }
        else { animator.SetBool("isRuning", false); }

    }

    public void Shoot()
    {
        animator.SetTrigger("isShoot");
        //gunScript.Shoot(Range, impactForce);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0) Death();
    }

    public void Death()
    {
        //Destroy(gameObject);
    }


}

