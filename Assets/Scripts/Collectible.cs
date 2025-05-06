using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public bool playerNearby;
    private PlayerController playerC;
    
    

    
    private GameManager gameManager;


    //public string collectibleName;
    //public int collectibleCounter = 1;
    //public string collectibleText;

    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        

        //collectibleText = "You got a " + collectibleName + "!";

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (playerNearby && playerC.speed == 0 && playerC.dialogueShowing)
        {
            
            Destroy(gameObject);
            
           
        }

        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
