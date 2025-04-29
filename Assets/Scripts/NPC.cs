using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public bool playerNearby;
    public string dialogue;
    public TextMeshProUGUI dialogueTextUI;
    public RectTransform dialoguePanel;
    public bool dialogueShowing;
    private PlayerController playerC;
    private int paused = 0;
    private int resumed = 7;


    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNearby && !dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueTextUI.text = dialogue;
            dialogueTextUI.gameObject.SetActive(true);
            dialoguePanel.gameObject.SetActive(true);
            dialogueShowing = true;
            playerC.speed = paused;
        }
        else if (playerNearby && dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            dialogueTextUI.gameObject.SetActive(false);
            dialoguePanel.gameObject.SetActive(false);
            dialogueShowing = false;
            playerC.speed = resumed;
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
