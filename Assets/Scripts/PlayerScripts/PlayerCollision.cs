using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCollision : MonoBehaviour
{
    /* 
    Written by Christian Laverde

    This Script contains all the references to all player values that need to be manipulated by outside objects
    all interactions should go through this script, but direct changing of those values should be placed in a more relevant script
    if one exists
    */

    //Player Values to reference
    TimerScript playerTimer;

    [SerializeField] PlayerStats playerStats;


    //Player Values to track in script
    public int score = 0;
    public float recoveringFrames;
    bool recovering = false;

    //Tilemap reference
    public GameObject tilemapGameObject;
    public Tilemap tilemap;

    void Start(){
       playerTimer = gameObject.GetComponent<TimerScript>();

    }

    public void PlayerScore()
    {
        score += 1;
    }

    public void PlayerDamage(float damage)
    {
        if (!recovering)
        {
            //Damage player air supply by damage amount
            playerTimer.DamageBubble(damage);

            //Invincibility frames
            StartCoroutine(InvincibilityFrames());

            
        }
    }

    //Invincibility frames for the player for the length of time that recoveringFrames gives you
    IEnumerator InvincibilityFrames()
    {
        recovering = true;
        for (int i = 0; i < recoveringFrames; i++)
        {
            Debug.Log("Recovering");
            yield return new WaitForSeconds(.1f);
        }

        Debug.Log("Recovering Done");
        recovering = false;
    }

    //Code to destroy terrian, not a clue where this should go
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("touch");
        Vector2 hitPosition = Vector3.zero;
        if (tilemap != null && tilemapGameObject == collision.gameObject && playerStats.gassedUp)
        {
            
            Debug.Log("touches");
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = transform.position.x + playerStats.DashDirection.x;
                hitPosition.y = transform.position.y + playerStats.DashDirection.y;
                Debug.Log(hitPosition);
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }*/

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("touch");
        Vector2 hitPosition = Vector3.zero;
        if (tilemap != null && tilemapGameObject == other.gameObject && playerStats.gassedUp)
        {
            
            Debug.Log("touches");
            Vector2 contact = other.ClosestPoint(transform.position);
            
            if(playerStats.DashDirection.x > playerStats.DashDirection.y){
                contact.x += playerStats.DashDirection.x;
            }else{
                contact.y += playerStats.DashDirection.y;
            }
            Debug.Log(hitPosition);
            tilemap.SetTile(tilemap.WorldToCell(contact), null);
            
        }
    }




}



