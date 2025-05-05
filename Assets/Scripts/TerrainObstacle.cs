using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObstacle : MonoBehaviour
{
    private PlayerController playerC;
    private MonsterBehavior monsterB;
    public string[] monsterRequired;
    
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        monsterB = GameObject.Find("Current Monster").GetComponent<MonsterBehavior>();

        bool containsMonster = Array.Exists(monsterRequired, monster => monster == monsterB.monsterName);
        
        if (playerC.hasMonster && containsMonster && monsterB.followPlayer)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled= true;
        }

    }



}
