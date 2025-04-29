using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public string monsterName;
    public bool followPlayer;
    private PlayerController playerC;
    public GameObject trigger;

    private Transform target;
    public float speed;
    public bool touchingPlayer;

    public bool isCurrentMonster;

    



    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

        target = GameObject.Find("Player").GetComponent<Transform>();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerMovement();
    }

    private void Update()
    {
        

        if (!playerC.hasMonster && playerC.canHaveMonster && touchingPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            isCurrentMonster = true;
            followPlayer = true;
            playerC.hasMonster = true;
            playerC.canHaveMonster = false;
            gameObject.name = "Current Monster";
        }
        else if (playerC.hasMonster && !playerC.canHaveMonster && touchingPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            followPlayer = false;
            playerC.hasMonster = false;
            playerC.canHaveMonster = true;
            gameObject.name = "Monster";
        }


        



    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingPlayer = true;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingPlayer = false;
        }
    }

    public void FollowPlayerMovement()
    {
        if (followPlayer == true && isCurrentMonster) 
        {
            //disable trigger so that you cant hit it again

            trigger.SetActive(false);

            //move towards the player


            if (!touchingPlayer)
            {
                speed = 6;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
                
            }
            else if (touchingPlayer)
            {
                speed = 0;
            }
        }
        else
        {
            trigger.SetActive(true);
        }
    }

}
