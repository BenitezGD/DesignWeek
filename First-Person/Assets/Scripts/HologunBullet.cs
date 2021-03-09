using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologunBullet : MonoBehaviour
{
    public GameObject player;
    Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Debug.Log(newPosition);
            player.transform.position = newPosition;
            Destroy(this.gameObject);
        }
    }
}
