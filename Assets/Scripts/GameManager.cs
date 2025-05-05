using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int collectiblesFound = 0;
    public TextMeshProUGUI collectiblesFoundText;
    public TextMeshProUGUI endGameText;
    private PlayerController playerC;


    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collectiblesFound == 100)
        {
            GameOver();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void GameOver()
    {
        endGameText.gameObject.SetActive(true);
        playerC.speed = 0;
    }







}
