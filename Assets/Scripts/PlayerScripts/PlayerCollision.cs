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
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("touch");
        if (tilemap != null && tilemapGameObject == collision.gameObject)
        {
            Debug.Log("touches");
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector3 hitPosition = transform.position + new Vector3(0f, -0.5f, 0f);
                Debug.Log(collision.transform.position);
                tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
            }
        }
    }




}



