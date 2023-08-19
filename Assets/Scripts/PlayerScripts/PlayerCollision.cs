using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool gassedUp;
    public float recoveringFrames;
    bool recovering = false;
    

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




}



