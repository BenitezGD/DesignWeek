using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Score score;
    public float rotate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotate * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        score.addScore();
    }
}
