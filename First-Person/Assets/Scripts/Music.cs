using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource nightStalker;
    public AudioSource LKM;
    public AudioSource GME;
    public AudioSource somethingSecret;

    public GameObject lastTrigger;

    public Image hl; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger1" && lastTrigger.name != "Trigger1")
        {
            GME.Play();
            LKM.Stop();
            nightStalker.Stop();
            somethingSecret.Stop();
            lastTrigger = other.gameObject;
        }

        if (other.gameObject.name == "Trigger2" && lastTrigger.name != "Trigger2")
        {
            GME.Stop();
            LKM.Play();
            nightStalker.Stop();
            somethingSecret.Stop();
            lastTrigger = other.gameObject;
        }

        if (other.gameObject.name == "Trigger3" && lastTrigger.name != "Trigger3")
        {
            GME.Stop();
            LKM.Stop();
            nightStalker.Play();
            somethingSecret.Stop();
            lastTrigger = other.gameObject;
        }

        if (other.gameObject.name == "Trigger4" && lastTrigger.name != "Trigger4")
        {
            GME.Stop();
            LKM.Stop();
            nightStalker.Stop();
            somethingSecret.Play();
            hl.gameObject.SetActive(true);
            lastTrigger = other.gameObject;
        }
    }
}
