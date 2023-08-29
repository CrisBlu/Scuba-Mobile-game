using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //This script should be the base for all enemy collisions with the player, don't affect any player variables from here; instead call playerscript functions
    PlayerCollision playerCollisionScript;

    //temp, attackPower should be in the specfifc enemy scripts
    float attackPower = 5f;
    
    
    void Start()
    {
        playerCollisionScript = GameObject.Find("Hero").GetComponent<PlayerCollision>();
    }

    //Refer to your notes and change the collision based on this function's input
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Temporary measure
        if(other.name == "Hero")
        {
            EntityCollide(attackPower);
        }
    }


    protected void EntityCollide(float damage)
    {
        if (playerCollisionScript.gassedUp)
        {
            Destroy(gameObject);
        }
        else
        {
            playerCollisionScript.PlayerDamage(damage);
        }
            
    
    }
}
