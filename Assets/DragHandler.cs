using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    /* 
    Written by Christian Laverde

    This script is only to be used to detect when the player swipes for the purpose of the hero dashing
    it will detect the dash and flip the gassedUp switch
    */


    public Rigidbody2D rigidBody;

    //THIS IS TEMPORARY, MOVE THIS TO A DIFFERENT SCRIPT OR I'LL GUT YOU
    public int DASH_SPEED;
    public movement script;
    [SerializeField] PlayerStats statsScript;
    
 
    public void OnDrag(PointerEventData _EventData)
    {
        
    }
 
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 swipeVector = (eventData.position - eventData.pressPosition).normalized;
        Debug.Log("norm + " + swipeVector);
        Vector2 dashVector = swipeVector * DASH_SPEED;

        if(statsScript.GasPips != 0)
        {
            StartCoroutine(Dash(dashVector));
        }
            
       

    }

    IEnumerator Dash(Vector2 dashVector)
    {
        //Set Gravity to 0
        rigidBody.gravityScale = 0;

        //Turn off movement script to not interfere with dash (DO NOT FUCKING KEEP IT LIKE THIS, MERGE MOVEMENT AND DASHING INTO ONE UNIVERSAL SCRIPT)
        script.enabled = false;

        //flip dash bool
        statsScript.gassedUp = true;
        statsScript.GasPips -= 1f;

        //Set rigidBody velocity to equal dash vector for .2 seconds, then set it back to 0
        rigidBody.velocity = dashVector;
        yield return new WaitForSeconds(.2f);
        rigidBody.velocity = new Vector2(0, 0);

        //Turn back on the movement script and turn back on gravity
        script.enabled = true;

        //Make this a constant in player stats
        rigidBody.gravityScale = 3;

        //Flip dash bool back
        statsScript.gassedUp = false;
        
    }


}

