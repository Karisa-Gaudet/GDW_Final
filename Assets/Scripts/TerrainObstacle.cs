using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainObstacle : MonoBehaviour
{
    private PlayerController playerC;
    private MonsterBehavior monsterB;
    public string monsterRequired;
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        monsterB = GameObject.Find("Monster").GetComponent<MonsterBehavior>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.hasMonster && monsterB.monsterName == monsterRequired && monsterB.followPlayer)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled= true;
        }

    }

}
