using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float speed;
    public float forcePush;
    public bool fired = false;

    public float chargeTime = 0f;
    public float maxChargeTime = 5f;
    public float minChargeTime = 0.3f;

    // Update is called once per frame
    void Update()
    {
        //Main Fire ----------------------------------------------------------------------------------
        if(Input.GetMouseButton(0) && !fired)
        {
            chargeTime += Time.deltaTime;
            Debug.Log(chargeTime);   
        }

        if (Input.GetMouseButtonUp(0) && !fired)
        {
            if (chargeTime > 2f)
            {
                chargeTime = 2f;
            }

            float percent = chargeTime / maxChargeTime;

            if (percent >= minChargeTime)
            {
                GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
                HologunBullet pearl = projectile.GetComponent<HologunBullet>();
                pearl.player = this.transform.parent.parent.gameObject;
                pearl.gun = this;
                pearl.rb.AddForce(-transform.forward * speed * percent, ForceMode.Impulse);

                chargeTime = 0f;
                fired = true;
            }           
        }

        //ALT Fire ----------------------------------------------------------------------------------------
        if(Input.GetMouseButton(1))
        {
            chargeTime += Time.deltaTime;
            Debug.Log(chargeTime);
        }

        if(Input.GetMouseButtonUp(1))
        {
            if(chargeTime > 2f)
            {
                chargeTime = 2f;
            }

            float percent = chargeTime / maxChargeTime;

            Rigidbody rb = this.transform.parent.parent.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * percent * forcePush, ForceMode.Impulse);
            
            chargeTime = 0;
        }
    }
}
