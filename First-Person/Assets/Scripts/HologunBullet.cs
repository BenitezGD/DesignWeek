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

    [SerializeField]
    GameObject teleportTargetEffect; //Particle effect created when ball hits the ground

    [SerializeField]
    float teleportTargetEffectGroundOffset; // How far above the ground will it be created

    [SerializeField]
    float teleportDelay; //Delay in seconds for teleportation after ball hits the ground

    [SerializeField]
    GameObject onTeleportEffect; //Create an effect when teleported to the target destination


    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * gravity);
    }

    private void Update()
    {
        time = +Time.deltaTime;

        if (time >= despawnTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            newPosition = new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z);
            //player.transform.position = newPosition;

            StartCoroutine(TeleportCoroutine());

            gun.fired = false;

            GameObject tempEffect = Instantiate(teleportTargetEffect, other.GetContact(0).point + other.GetContact(0).normal * teleportTargetEffectGroundOffset, teleportTargetEffect.transform.rotation);

            Destroy(tempEffect, teleportDelay);

            GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<MeshRenderer>().enabled = false;

            Destroy(this.gameObject, 5);
        }
    }

    private void OnDestroy()
    {
        // gun.fired = false;
    }

    IEnumerator TeleportCoroutine()
    {
        yield return new WaitForSeconds(teleportDelay);
        player.transform.position = newPosition;

        GameObject tempEffect = Instantiate(onTeleportEffect, transform.position, onTeleportEffect.transform.rotation);

        Destroy(tempEffect, 0.6f);
    }
}
