using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologun : MonoBehaviour
{
    Animator M471Animator;

    public GameObject bullet;
    public Transform muzzle;
    public float maxDistance;
    public float minDistance;
    public float forcePush;
    public bool fired = false;

    public float chargeTime = 0f;
    public float maxChargeTime = 5f;


    // Update is called once per frame
    void Update()
    {
        M471Animator = GetComponent<Animator>();

        //Main Fire ----------------------------------------------------------------------------------
        if (Input.GetButton("Fire1") && !fired)
        {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1") && !fired)
        {

            if (chargeTime > 2f)
            {
                chargeTime = 2f;
            }

            float percent = chargeTime / maxChargeTime;

            GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
            HologunBullet pearl = projectile.GetComponent<HologunBullet>();
            pearl.player = this.transform.parent.parent.gameObject;
            pearl.gun = this;
            pearl.rb.AddForce(transform.forward * (minDistance + (maxDistance * percent)), ForceMode.Impulse);


            M471Animator.SetTrigger("Fire_02"); //<------------------------ Right Here
            
            chargeTime = 0f;
            fired = true;
        }

        //ALT Fire ----------------------------------------------------------------------------------------
        if (Input.GetMouseButton(1))
        {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(1))
        {
            if (chargeTime > 2f)
            {
                chargeTime = 2f;
            }

            float percent = chargeTime / maxChargeTime;

            Rigidbody rb = this.transform.parent.parent.GetComponent<Rigidbody>();

            rb.AddForce(-transform.forward * percent * forcePush, ForceMode.Impulse);

            chargeTime = 0;
        }

        if (Input.GetButtonDown("Vertical"))
        {
            M471Animator.SetBool("walk", true);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            M471Animator.SetBool("walk", false);
        }

        if (Input.GetKeyDown("left shift"))
        {
            M471Animator.SetBool("Sprint", true);
        }
        if (Input.GetKeyUp("left shift"))
        {
            M471Animator.SetBool("Sprint", false);
        }
    }
}
