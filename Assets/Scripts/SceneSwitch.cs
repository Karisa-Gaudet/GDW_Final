using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;
    public Transform Target;
    private PlayerController playerC;
    public BoxCollider2D boxCollider;

    public string entryMessage;
    public TextMeshProUGUI textUI;
    public RectTransform panel;

    public bool displayMessage;

    public string location;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

        boxCollider = GetComponent<BoxCollider2D>();

        
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerC.hasMonster)
        {
            player.transform.position = Target.position;
            playerC.location = location;

        }

        if (other.tag == "Player" && playerC.hasMonster && entryMessage == "Monsters can't go indoors!")
        {
            panel.gameObject.SetActive(true);
            textUI.gameObject.SetActive(true);
            textUI.text = entryMessage;
            displayMessage = true;
        }
        else if (other.tag == "Player" && playerC.hasMonster && entryMessage == "")
        {
            player.transform.position = Target.position;
            playerC.location = location;
            displayMessage = false;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (displayMessage)
        {
            panel.gameObject.SetActive(false);
            textUI.gameObject.SetActive(false);
            displayMessage = false;
        }
    }






}
