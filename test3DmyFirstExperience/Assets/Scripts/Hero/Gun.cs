using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Camera cam;
    public CharacterController heroScript;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    public void Shoot(float range, float impactForce)
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            ISoldier target = hit.transform.GetComponent<ISoldier>();
            if (target != null)
            {
                target.DealDamage(hit, heroScript.Damage, impactForce);
            }


            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 1.5f);
        }
    }

}
