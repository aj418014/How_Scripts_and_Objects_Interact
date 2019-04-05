using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{

    public GameObject player;

    // Initializes on startup
    private void Start() 
    {
        player = GameObject.FindWithTag("Player"); //saves player as gameobject
    }



//***********************************************************
// FindInteractedObject()
//
// takes the name of what the player interacted with and then
// run's it's specific interaction function
//
// uses a variable npcName to save the name into a string
//
// checks the npcName across a list of npc's that are in the 
// game
//************************************************************
public void FindInteractedObject()
    {
        string npcName; //name of the npc interacted with
        GameObject npc; //npc interacted with

        Debug.Log("Hello I'm an NPC"); //test to make sure function was accessed

        npc = player.GetComponent<PlayerBehavior>().objectInteractedWith; //saves object player interacted with into the npc variable
        npcName = npc.name; //saves the npc's name into this variable
        if (npcName == "Bear") //if bear was interacted with
        {
            GetComponent<BearBehavior>().Interaction(); //run bear's interaction
        }
        else if (npcName == "Snail") //if snail was interacted with
        {
            GetComponent<SnailBehavior>().Interaction(); //run snails interaction
        }
    }
}
