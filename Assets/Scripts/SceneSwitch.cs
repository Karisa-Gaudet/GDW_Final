using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public GameObject player;
    public Transform Target;
    public GameObject monster;
    private PlayerController playerC;
    private MonsterBehavior monsterB;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        monsterB = GameObject.Find("Monster").GetComponent<MonsterBehavior>();
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.transform.position = Target.position;
        }
        
        if (playerC.hasMonster && monsterB.followPlayer)
        {
            //monster.transform.position = Target.position;
        }


    }




}
