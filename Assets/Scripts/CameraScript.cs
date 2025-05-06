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
        

        if (playerC.location == "Lab")
        {
            transform.position = new Vector3 (lab.position.x, lab.position.y, zPos);
        }

        if (playerC.location == "Red House")
        {
            transform.position = new Vector3 (redHouse.position.x, redHouse.position.y, zPos);
        }

        if (playerC.location == "Outside")
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
