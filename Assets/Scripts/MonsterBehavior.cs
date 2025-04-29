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

        //if (playerC.hasMonster && touchingPlayer)
        //{
            //isCurrentMonster = true;
            


           // if (followPlayer == false)
           // {
           // followPlayer = true;
           // }
       // }

    }

    private void Update()
    {
        //if (playerC.hasMonster && Input.GetKeyDown(KeyCode.Space))
        //{
           // playerC.hasMonster = false;
            //isCurrentMonster = false;
            //followPlayer = false;
            //playerC.canHaveMonster = true;
        //}

        if (!playerC.hasMonster && playerC.canHaveMonster && touchingPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            isCurrentMonster = true;
            followPlayer = true;
            playerC.hasMonster = true;
            playerC.canHaveMonster = false;
        }
        else if (playerC.hasMonster && !playerC.canHaveMonster && touchingPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            followPlayer = false;
            playerC.hasMonster = false;
            playerC.canHaveMonster = true;
        }


        if (isCurrentMonster && monsterName == "Mowth")
        {
            // game object tallGrass box collider2D set active = false
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
        if (followPlayer == true && isCurrentMonster) //maybe move iscurrentmonster to someplace else if it doesnt work
        {
            //disable trigger so that you cant hit it again

            trigger.SetActive(false);

            //move towards the player


            if (touchingPlayer == false)
            {
                speed = 6;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            }
            else if (touchingPlayer == true)
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
