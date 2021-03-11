using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCTrigger : MonoBehaviour
{
    public Text npcDialog;
    public Text prompt;

    bool inRange = false;
    bool displayText = false;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && inRange)
        {
            npcDialog.text = "Hey this is to test the dialog box, how is it?";
            displayText = true;
        }

        if(displayText)
        {
            time += Time.deltaTime;

            if(time > 3)
            {
                npcDialog.text = "";
                displayText = false;
                time = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            prompt.gameObject.SetActive(true);
            inRange = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            prompt.gameObject.SetActive(false);
            inRange = false;
        }
    }
}
