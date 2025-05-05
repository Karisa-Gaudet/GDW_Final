using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;
    public Transform Target;
    private PlayerController playerC;
    public BoxCollider2D boxCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();

        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerC.hasMonster)
        {
            player.transform.position = Target.position;
        }
    }




}
