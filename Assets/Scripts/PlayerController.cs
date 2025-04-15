using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    private Rigidbody2D rb;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }

        Movement();
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
}
