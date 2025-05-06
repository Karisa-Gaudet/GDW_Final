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
    private float followSpeed = 4.0f;
    public bool touchingPlayer;

    public bool isCurrentMonster;

    public Rigidbody2D playerRb;



    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

        target = GameObject.Find("Player").GetComponent<Transform>();

        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayerMovement();
    }

    private void Update()
    {
        

        if (!playerC.hasMonster && playerC.canHaveMonster && touchingPlayer && !playerC.touchingSwitch && Input.GetKeyDown(KeyCode.Space))
        {
            isCurrentMonster = true;
            followPlayer = true;
            playerC.hasMonster = true;
            playerC.canHaveMonster = false;
            gameObject.name = "Current Monster";
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (playerC.hasMonster && !playerC.canHaveMonster && touchingPlayer && !playerC.touchingSwitch && Input.GetKeyDown(KeyCode.Space))
        {
            followPlayer = false;
            playerC.hasMonster = false;
            playerC.canHaveMonster = true;
            gameObject.name = "Monster";
            GetComponent<BoxCollider2D>().enabled=true;
        }


        



    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touchingPlayer = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
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
            
            if (!touchingPlayer)
            {
                speed = followSpeed;
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
                
            }
            else if (touchingPlayer)
            {
                speed = 0;
            }
        }
        
    }

}
