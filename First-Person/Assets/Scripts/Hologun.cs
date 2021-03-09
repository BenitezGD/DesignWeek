using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hologun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject fired = Instantiate(bullet, muzzle.position, muzzle.rotation);
            HologunBullet b = fired.GetComponent<HologunBullet>();
            b.player = this.transform.parent.parent.gameObject;


        }
    }
}
