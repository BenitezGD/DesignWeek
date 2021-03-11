using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologunBullet : MonoBehaviour
{
    public GameObject player;
    public Hologun gun;
    public float despawnTime;
    float time = 0f;
    public Rigidbody rb;
    public float gravity;
    Vector3 newPosition;


    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravity);
    }

    private void Update()
    {
        time = +Time.deltaTime;

        if(time >= despawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            newPosition = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
            player.transform.position = newPosition;
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        gun.fired = false;
    }
}
