using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    private Rigidbody2D rb;
    public bool hasMonster = false;
    public bool canHaveMonster = true;
    public bool monsterNearby = false;

    

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && monsterNearby && !hasMonster && canHaveMonster)
        {
            //hasMonster = true;
            //canHaveMonster = false;
        }

        

    }



    public void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 moveVector = new Vector2(horizontalInput, verticalInput);
        rb.velocity = (moveVector * speed);

        //transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        //transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            
        }

        if (collision.gameObject.CompareTag("Monster"))
        {
            monsterNearby = true;
        } 
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            monsterNearby = false;
        }
    }




}
