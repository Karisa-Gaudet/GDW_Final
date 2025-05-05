using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public bool playerNearby;
    public string collectibleName;
    public string collectibleText;
    public TextMeshProUGUI collectibleTextUI;
    public RectTransform dialoguePanel;
    public bool dialogueShowing;
    private PlayerController playerC;
    private int paused = 0;
    private int resumed = 7;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        

        collectibleText = "You got a " + collectibleName + "!";

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby && !dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            collectibleTextUI.text = collectibleText;
            collectibleTextUI.gameObject.SetActive(true);
            dialoguePanel.gameObject.SetActive(true);
            dialogueShowing = true;
            playerC.speed = paused;
        }
        else if (playerNearby && dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            collectibleTextUI.gameObject.SetActive(false);
            dialoguePanel.gameObject.SetActive(false);
            dialogueShowing = false;
            playerC.speed = resumed;
            Destroy(gameObject);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
