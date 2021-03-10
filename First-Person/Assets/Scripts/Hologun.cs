using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float speed;
    public bool fired = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !fired)
        {
            GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);
            HologunBullet pearl = projectile.GetComponent<HologunBullet>();
            pearl.player = this.transform.parent.parent.gameObject;
            pearl.gun = this;
            pearl.rb.AddForce(-transform.forward * speed, ForceMode.Impulse);

            fired = true;
        }
    }
}
