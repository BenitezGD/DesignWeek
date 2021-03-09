using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologunBullet : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    Vector3 newPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            newPosition = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Debug.Log(newPosition);
            player.transform.position = newPosition;
            Destroy(this.gameObject);
        }
    }
}
