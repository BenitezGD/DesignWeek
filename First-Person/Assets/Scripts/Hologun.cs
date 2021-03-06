using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hologun : MonoBehaviour
{

    Animator M471Animator;

    AudioManager M471AudioManager;

    public GameObject bullet;
    public Text reloadText;
    public Text ammoText;
    public Transform muzzle;
    public Image chargeBar;

    public float maxDistance;
    public float minDistance;
    public float minPush;
    public float maxPush;
    public bool canFire = true;

    private bool canFirePush = true;
    private float cooldown = 0;

    public float chargeTime = 0f;
    public float maxChargeTime = 5f;

    public int clip = 3;
    public int ammoPool = 9;
    
    [SerializeField]
    GameObject gunShotEffect;

    bool reloading = false;
    int missingAmmo;
    float reloadTime = 0f;

    public void Start()
    {
        M471Animator = GetComponent<Animator>();
        M471AudioManager = GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if there is ammo in clip
        if(clip == 0)
        {
            canFire = false;
            reloadText.gameObject.SetActive(true);

        }

        else
        {
            reloadText.gameObject.SetActive(false);
        }

        //Main Fire ----------------------------------------------------------------------------------
        if (Input.GetButton("Fire1") && canFire)
        {
            chargeTime += Time.deltaTime;
            chargeBar.fillAmount = chargeTime / maxChargeTime;

            if (chargeTime > 2f)
            {
                chargeTime = 2f;
            }
        } 

        if (Input.GetButtonUp("Fire1")  && canFire )
        {
            float percent = chargeTime / maxChargeTime;

            GameObject projectile = Instantiate(bullet, muzzle.position, muzzle.rotation);

            gunShotEffect.GetComponent<ParticleSystem>().Play();

            HologunBullet pearl = projectile.GetComponent<HologunBullet>();
            pearl.player = this.transform.parent.parent.gameObject;
            pearl.gun = this;
            pearl.rb.AddForce(transform.forward * (minDistance + (maxDistance * percent)), ForceMode.Impulse);

            M471Animator.SetTrigger("Fire_02");

            chargeBar.fillAmount = 0;
            clip--;
            chargeTime = 0f;
            canFire = false;
        }

        //ALT Fire -----------------------------------------------------------------------------------
        if (Input.GetMouseButton(1) && canFirePush)
        {
            chargeTime += Time.deltaTime;
            chargeBar.fillAmount = chargeTime / maxChargeTime;

            if(chargeTime > 2f)
            {
                chargeTime = 2f;
            }
        }

        if (Input.GetMouseButtonUp(1) && canFirePush)
        { 
            float percent = chargeTime / maxChargeTime;

            Rigidbody rb = this.transform.parent.parent.GetComponent<Rigidbody>();
            rb.AddForce(-transform.forward * (minPush + (percent * maxPush)), ForceMode.Impulse);
            M471Animator.SetTrigger("ALT_Fire_01");

            chargeBar.fillAmount = 0;
            chargeTime = 0;
            canFirePush = false;
        }

        if (!canFirePush)
        {
            cooldown += Time.deltaTime;
            Debug.Log(cooldown);

            chargeTime = 0;

            if(cooldown >= 3)
            {
                canFirePush = true;
                cooldown = 0;
            }
        }

        //Reload -------------------------------------------------------------------------------------
        //Starts the reload sequence
        if (Input.GetKeyUp("r") && clip < 3 && !reloading)
        {
            M471Animator.SetTrigger("Reload_01A");
            reloading = true;
            canFire = false;
        }

        //reload sequence
        if(reloading)
        {
            reloadTime += Time.deltaTime; //reloadTime adjusts the time between inserting shells

            if(reloadTime > 1f) //change this to how long the reload animation takes
            {
                clip = 3;
                reloadTime = 0f;
                reloading = false;
                canFire = true;
            }   
        }




        //Update UI
        ammoText.text = clip + "";


        //Animations ---------------------------------------------------------------------------------
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
        if (Input.GetKey("k"))
        {
            M471Animator.SetTrigger("Inspect");
        }
    }

  
}
