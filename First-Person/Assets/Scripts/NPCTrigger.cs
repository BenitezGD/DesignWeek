using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCTrigger : MonoBehaviour
{
    public Text npcDialog;
    public Text prompt;
    public Text npcCount;
    public Text npcFound;

    bool inRange = false;
    bool displayText = false;
    float time = 0f;
    string npcName;

    AudioSource oof;

    bool atlas = false;
    bool pbody = false;
    bool space = false;
    bool wheatley = false;
    bool steve = false;
    bool threelegs = false;
    bool happyflying = false;
    bool medaton2 = false;
    bool cool = false;
    bool karen = false;
    bool hazmat = false;

    int found = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        npcCount.text = found + "/11";

        if (Input.GetKeyDown("e") && inRange)
        {
            if(npcName == "ATLAS")
            {
                npcDialog.text = "It can't talk, it seems to be searching for its companion. " +
                    "It gestures that it's companion is tall & skinny.";
                displayText = true;

                if(atlas == false)
                {
                    atlas = true;
                    found++;
                }
            }

            if (npcName == "P-Body")
            {
                npcDialog.text = "It can't talk, it seems to be searching for its companion. " +
                    "It gestures that it's companion is short & round.";
                displayText = true;

                if (pbody == false)
                {
                    pbody = true;
                    found++;
                }
            }

            if(npcName == "Space")
            {
                npcDialog.text = "oH? a Human wHO can TAkE ME TO spAAaAaaAce!!";
                displayText = true;

                if (space == false)
                {
                    space = true;
                    found++;
                }
            }

            if(npcName == "Wheatley")
            {
                npcDialog.text = "HEY you, yes you. The person who is literally just a floating arm." +
                    " Mind getting out of he- NO wait where are you going?";
                displayText = true;

                if (wheatley == false)
                {
                    wheatley = true;
                    found++;
                }
            }

            if(npcName == "Steve")
            {
                oof.Play();

                if (steve == false)
                {
                    steve = true;
                    found++;
                }
            }

            if(npcName == "3Legs")
            {
                npcDialog.text = "Pretty high wall. If only you could get over it...";
                displayText = true;

                if (threelegs == false)
                {
                    threelegs = true;
                    found++;
                }
            }

            if (npcName == "Happyflying")
            {
                npcDialog.text = "Hiya stranger! Seems you're trapped here. " +
                    "Follow the orange glow to find your way out!";
                displayText = true;

                if (happyflying == false)
                {
                    happyflying = true;
                    found++;
                }
            }

            if(npcName == "Karen")
            {
                npcDialog.text = "GIVE ME THE KRABBY PA-- sorry force of habit";
                displayText = true;

                if (karen == false)
                {
                    karen = true;
                    found++;
                }
            }

            if (npcName == "Cool")
            {
                npcDialog.text = "Made it to the top eh? Go out and explore a bit. " +
                    "I've seen some strange characters wandering about";
                displayText = true;

                if (cool == false)
                {
                    cool = true;
                    found++;
                }
            }

            if (npcName == "Medaton 2.0")
            {
                npcDialog.text = "You know what's breathtaking? A cyberpunk-style game made by 6 people " +
                    "has fewer bugs than one made by a AAA studio!";
                displayText = true;

                if (medaton2 == false)
                {
                    medaton2 = true;
                    found++;
                }
            }

            if (npcName == "Hazmat")
            {
                npcDialog.text = "That gun can propel you up if you jump. " +
                    "Gotta let it cooldown after using that mode tho.";
                displayText = true;

                if (hazmat == false)
                {
                    hazmat = true;
                    found++;
                }
            }
        }

        if(displayText)
        {
            time += Time.deltaTime;

            if(time > 4)
            {
                npcDialog.text = "";
                displayText = false;
                time = 0f;
            }
        }


        if(atlas && pbody && space && wheatley && steve && hazmat && threelegs && cool && medaton2 && karen && happyflying)
        {
            npcFound.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            npcName = other.gameObject.name;
            prompt.gameObject.SetActive(true);
            inRange = true;
        }

        if(other.gameObject.tag == "NPC" && other.gameObject.name == "Steve")
        {
            npcName = other.gameObject.name;
            prompt.gameObject.SetActive(true);
            inRange = true;
            oof = other.GetComponent<AudioSource>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "NPC")
        {
            npcName = "";
            prompt.gameObject.SetActive(false);
            inRange = false;
        }
    }
}
