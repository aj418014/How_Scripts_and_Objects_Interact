using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //variables******************************************************
    public float speed = 7.5f; // the default speed at which the player moves
    public int rotateSpeed = 90; // the default speed at which the player rotates
    public GameObject objectInteractedWith; // the object that the player hit with a raycast after
    public string[] inventory = new string[4]; //array of strings that holds names of what is in player inventory

    // Update is called once per frame
    void Update()
    {

        PlayerMovement(); //function that moves the player
        InteractWithNPC(); //function of what to do if the player interacts with an npc
    }

    //*****************************************************************
    // Player Movement Function
    //
    // Moves the player based on their input on keys w, a, s, and d,
    //
    // Uses a speed and rotate speed variables that can be changed (listed above)
    // to determine how fast the player moves and rotates
    //
    // Uses no parameters and returns nothing
    //*****************************************************************
    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * Time.deltaTime * speed); // move forward
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed); // turn left
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed); // turn right
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * speed); // move back
    }

    //******************************************************************
    // OnCollisionEnter
    //
    // Controls what happens on collision with another object
    //
    // Uses a collision vvariable as a parameter
    //******************************************************************

    private void OnCollisionEnter(Collision collision)
    {
        CollectOject(collision); //function that will collect an object and add it's name to your
                                 //inventory. (listed below)
    }

    //*******************************************************************
    // Collect Object
    //
    // When the player runs into an object tagged as collectable item
    // it will be added to a string array to be access by checks for items
    // in other npc scripts
    //
    // Uses a collision variable as a parameter
    //
    //********************************************************************

    void CollectOject(Collision collision)
    {
        int totalItems = 0; //the total items you have. ups by one to save each item in a different slot

        if (collision.gameObject.tag == "Obtainable Item") // checks to see if the item is obtainable
        {

            inventory[totalItems] = collision.gameObject.name; //saves game objects name into player inventory
            
            Destroy(collision.gameObject); //destroys the game object
        }
        
    }

    //runs interactions between NPC and player

    //***************************************************************************
    //InteractWithNPC
    //
    // sends out a raycast in front of the player only when e is pressed
    //
    // if that raycast hits an object with the tag Interactable NPC it takes the
    // game object and and saves it as object interacted with
    //
    // it will then let you know that an npc was interacted with
    //
    //
    private void InteractWithNPC()
    {
        RaycastHit hit; //returns information about the object hit by the raycast

        if(Input.GetKeyDown(KeyCode.E)) // if the player presses e send out a raycast
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3)) //returns true when raycast hits an object
                                                                                    //saves the information into hit
            {

                if (hit.collider.gameObject.tag == "Interactable NPC") //If the raycast hits an interactable npc run the NPC's Behavior Script      
                {
                    objectInteractedWith = hit.collider.gameObject; //saves object interacted with  into a string variable for use in other scripts

                    Debug.Log("NPC was interacted with!"); //Check to make sure if statement is function
                    objectInteractedWith.GetComponent<NPCBehavior>().FindInteractedObject();// runs the npc's behavior class which will specifically access each script needed for each npc
                }
            }
        }
    }
}
