using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int collectibleScore = 0;
    public TextMeshProUGUI collectiblesFoundText;
    public TextMeshProUGUI endGameText;
    private PlayerController playerC;
    


    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        
        

        Score(collectibleScore);
    }

    // Update is called once per frame
    void Update()
    {

        if (playerC.collected)
        {
            Score(1);
            playerC.collected = false;
        }

        if (collectibleScore == 100)
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

   public void Score(int score)
    {
        
            collectibleScore += score;
            collectiblesFoundText.text = "Found: " + collectibleScore;
 
    }





}
