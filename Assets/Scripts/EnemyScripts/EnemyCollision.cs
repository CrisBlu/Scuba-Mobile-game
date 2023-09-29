using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //This script should be the base for all enemy collisions with the player, don't affect any player variables from here; instead call playerscript functions
    PlayerStats playerStatsScript;
    PlayerCollision playerCollisionScript;

    [SerializeField] Animator animator;

    //temp, attackPower should be in the specfifc enemy scripts
    float attackPower = 5f;
    
    
    void Start()
    {
        playerCollisionScript = GameObject.Find("Hero").GetComponent<PlayerCollision>();
        playerStatsScript = GameObject.Find("Hero").GetComponent<PlayerStats>();
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
        if (playerStatsScript.gassedUp)
        {
            StartCoroutine(Death());
        }
        else
        {
            playerCollisionScript.PlayerDamage(damage);
        }
            
    
    }

    IEnumerator Death()
    {
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        animator.SetBool("Dying", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
