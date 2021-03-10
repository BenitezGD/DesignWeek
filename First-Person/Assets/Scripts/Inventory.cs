using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject m471Hologun;
    public GameObject m672SonicEmitter;

    private void Start()
    {
        m471Hologun.gameObject.SetActive(true);
        m672SonicEmitter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            m471Hologun.gameObject.SetActive(true);
            m672SonicEmitter.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            m471Hologun.gameObject.SetActive(false);
            m672SonicEmitter.gameObject.SetActive(true);
        }
    }
}
