using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    public PlayerController playerC;
    public GameObject player;
    public Transform playerTransform;
    public float xRangePos;
    public float xRangeNeg;
    public float yRangePos;
    public float yRangeNeg;
    public int zPos = -1;

    public Transform lab;
    public Transform redHouse;
    public Transform purpleHouse;
    public Transform pinkHouse;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerC = player.GetComponent<PlayerController>();
        playerTransform = player.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.location == "Forest")
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);

            if (transform.position.x < 3.5f)
            {
                transform.position = new Vector3(3.5f, transform.position.y, zPos);
            }
            if (transform.position.x > 19.6f)
            {
                transform.position = new Vector3(19.6f, transform.position.y, zPos);
            }
            if (transform.position.y < 34.7f)
            {
                transform.position = new Vector3(transform.position.x, 34.7f, zPos);
            }
            if (transform.position.y > 47.8f)
            {
                transform.position = new Vector3(transform.position.x, 47.8f, zPos);
            }
        }
        if (playerC.location == "Pond")
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);

            if (transform.position.x < 36.5f)
            {
                transform.position = new Vector3(36.5f, transform.position.y, zPos);
            }
            if (transform.position.x > 52.7f)
            {
                transform.position = new Vector3(52.7f, transform.position.y, zPos);
            }
            if (transform.position.y < -22.2f)
            {
                transform.position = new Vector3(transform.position.x, -22.2f, zPos);
            }
            if (transform.position.y > -9.7f)
            {
                transform.position = new Vector3(transform.position.x, -9.7f, zPos);
            }
        }

        if (playerC.location == "Cliffs")
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);

            if (transform.position.x < -58.4f)
            {
                transform.position = new Vector3(-58.4f, transform.position.y, zPos);
            }
            if (transform.position.x > -52.8f)
            {
                transform.position = new Vector3(-52.8f, transform.position.y, zPos);
            }
            if (transform.position.y < 6.7f)
            {
                transform.position = new Vector3(transform.position.x, 6.7f, zPos);
            }
            if (transform.position.y > 31.1f)
            {
                transform.position = new Vector3(transform.position.x, 31.1f, zPos);
            }
        }

        if (playerC.location == "Lab")
        {
            transform.position = new Vector3 (lab.position.x, lab.position.y, zPos);
        }

        if (playerC.location == "Red House")
        {
            transform.position = new Vector3 (redHouse.position.x, redHouse.position.y, zPos);
        }

        if (playerC.location == "Purple House")
        {
            transform.position = new Vector3 (purpleHouse.position.x, purpleHouse.position.y, zPos);
        }

        if (playerC.location == "Pink House")
        {
            transform.position = new Vector3 (pinkHouse.position.x, pinkHouse.position.y, zPos);
        }

        if (playerC.location == "Town")
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);

            if (transform.position.x < xRangeNeg)
            {
                transform.position = new Vector3(xRangeNeg, transform.position.y, zPos);
            }
            if (transform.position.x > xRangePos)
            {
                transform.position = new Vector3(xRangePos, transform.position.y, zPos);
            }

            if (transform.position.y < yRangeNeg)
            {
                transform.position = new Vector3 (transform.position.x, yRangeNeg, zPos);
            }
            if (transform.position.y  > yRangePos)
            {
                transform.position = new Vector3 (transform.position.x, yRangePos, zPos);
            }


        }

       




    }







}
