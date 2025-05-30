using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterBehavior : MonoBehaviour
{
    public string monsterName;
    public bool followPlayer;
    private PlayerController playerC;
    public GameObject trigger;

    private Transform target;
    public float speed;
    private float followSpeed = 4.5f;
    public bool touchingPlayer;

    public bool isCurrentMonster;

    public Rigidbody2D playerRb;

    public SpriteRenderer sprite;

    



    // Start is called before the first frame update
    void Start()
    {
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

        target = GameObject.Find("Player").GetComponent<Transform>();

        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

        sprite = GetComponentInChildren<SpriteRenderer>();


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
            
        }
        else if (playerC.hasMonster && !playerC.canHaveMonster && touchingPlayer && !playerC.touchingSwitch && Input.GetKeyDown(KeyCode.Space))
        {
            followPlayer = false;
            playerC.hasMonster = false;
            playerC.canHaveMonster = true;
            gameObject.name = "Monster";
            
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

        float distance = Vector3.Distance(target.position, transform.position);

        if (followPlayer && isCurrentMonster) 
        {
            //flip the sprite

            if (playerC.horizontalInput < 0)
            {
                sprite.flipX = true;
            }
            if (playerC.horizontalInput > 0)
            {
                sprite.flipX = false;
            }

            if (distance > 10)
            {
                transform.position = target.position; 
            }

            

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
