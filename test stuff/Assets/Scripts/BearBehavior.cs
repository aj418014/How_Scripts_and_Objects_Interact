using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBehavior : NPCBehavior
{
    
    int talkCount = 0; //amount of times player has talked to this specific npc

    //***********************************************************************
    // Interaction
    // 
    // Runs the interactions that the player has with the specific npc
    //
    // uses variable talkCount to keep track of how many times the player has
    // interacted with this npc
    //
    //takes no parameters and returns nothing
    //
    //***********************************************************************

    public void Interaction()
    {
        if (talkCount == 10) //if player talked to the bear 10 times then play this
                             //Listed first to take priority over other if statements
        {
            Debug.Log("Thank you for talking with me so much");
            talkCount++; //increase talkcount
        }
        else if (playerHasQuestItem() == true && talkCount > 1) //if player has the pineapple bear will say this
        {
            Debug.Log("Thank you for the Pineapple!");
            talkCount++; //increase talkcount
        }

        else //otherwise bear will tell you what he wants
        {
            Debug.Log("Help I lost my Pineapple :(");
            talkCount++; //increase talkcount
        }
    
    }
    //*****************************************************************
    // PlayerHasQuestItem
    //
    // Checks to see if the player has the specified quest item in their
    // inventory
    //
    // returns true if player has the needed quest item
    // returns false if they do not have it
    //******************************************************************
    bool playerHasQuestItem()
    {
        for (int i = 0; i <4; i++) //loop to check the player's inventory
        {

            if (player.GetComponent<PlayerBehavior>().inventory[i] == "Pineapple") //checks to see if player has pineapple
            {
                return true;
            }
        }
        return false; //if the player doesn't have the pineapple
    }
   
}
