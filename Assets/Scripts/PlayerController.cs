using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
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
    public bool npcNearby = false;

    private Animator animator;
    private SpriteRenderer sr;
    private string currentAnim;
    

    public bool collectibleNearby = false;
    public bool dialogueShowing;
    public GameObject currentCollectible;
    public string collectibleText;
    public string collectibleName;
    public TextMeshProUGUI collectibleTextUI;
    public RectTransform dialoguePanel;
    private int paused = 0;
    private int resumed = 5;

    public bool collected;

    public bool touchingSwitch;

    public GameManager gameManager;

    public string location;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponentInChildren<Animator>();

        sr = GetComponentInChildren<SpriteRenderer>();

        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();

        Collectibles();

        collectibleText = "You got " + collectibleName + "!";


    }



    public void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveVector = new Vector2(horizontalInput, verticalInput).normalized;


        rb.velocity = (moveVector * speed);

        //only change animation if the player is moving
        if (moveVector != Vector2.zero)
        {
            //horizontal movement
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                ChangeAnim("walk_hor");

                if (horizontalInput > 0)
                {
                    sr.flipX = false;
                }
                else if (horizontalInput < 0)
                {
                    sr.flipX = true;   
                }
            }
            //vertical movement
            else
            {
                if (verticalInput > 0)
                {
                    ChangeAnim("walk_vert_up");
                    
                }
                else if (verticalInput < 0)
                {
                    ChangeAnim("walk_vert");
                    
                }
            }
        }

        //transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        //transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);
    }

    void ChangeAnim(string anim)
    {
        if (currentAnim == anim) return;

        animator.Play(anim);
        currentAnim = anim;
    }

    public void Collectibles()
    {
        if (collectibleNearby && !dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            
            collectibleTextUI.text = collectibleText;
            collectibleTextUI.gameObject.SetActive(true);
            dialoguePanel.gameObject.SetActive(true);
            dialogueShowing = true;
            speed = paused;
            collected = true;
            

        }
        else if (dialogueShowing && Input.GetKeyDown(KeyCode.Space))
        {
            
            collectibleTextUI.gameObject.SetActive(false);
            dialoguePanel.gameObject.SetActive(false);
            dialogueShowing = false;
            speed = resumed;
            collected= false;
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Monster"))
        {
            monsterNearby = true;
        } 

        if (collision.gameObject.CompareTag("Collectible"))
        {
            collectibleNearby= true;
            currentCollectible = collision.gameObject;
            collectibleName = collision.name;
            
        }

        if (collision.gameObject.CompareTag("Switch"))
        {
            touchingSwitch = true;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            monsterNearby = false;
        }

        if (collision.gameObject.CompareTag("Collectible"))
        {
            collectibleNearby = false;
            currentCollectible = null;
            collectibleName = null;
        }

        if (collision.gameObject.CompareTag("Switch"))
        {
            touchingSwitch = false;
        }
    }

    


}
