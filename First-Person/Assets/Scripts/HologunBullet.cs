using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologunBullet : MonoBehaviour
{
    public GameObject player;
    public Hologun gun;
    public Rigidbody rb;
    Vector3 newPosition;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            newPosition = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
            Debug.Log(newPosition);
            player.transform.position = newPosition;
            gun.fired = false;
            Destroy(this.gameObject);
        }
    }
}
