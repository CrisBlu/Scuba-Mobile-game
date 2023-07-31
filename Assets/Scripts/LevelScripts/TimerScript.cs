using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timerInSeconds;
    public Transform bubbleMask;


    //Equal to 1/Timer in Seconds; Tells the script how much of the bubble gets 
    //taken away in a percentage of 1 each timer tick
    float bubbleUnit;

    
    

    
    void Start()
    {
        //Calculate the Bubble Unit
        bubbleUnit = 1/timerInSeconds;

    }

    
    void Update()
    {
        //Count the timer down, every update bubble takes damage equal to time passed
        if(timerInSeconds > 0)
        {

            //function to decrease bubble and air time
            DamageBubble(Time.deltaTime);

        }
    }

    public void DamageBubble(float damage){

        //Tick Timer Down
        timerInSeconds -= damage;

        //Vector to send the Sprite Mask down
        Vector2 maskDown;

        //Vector is now set by taking the deltatime and mutiplying to to be a percentage of 1
        //This way the bubble will decrease proportinal to the air left
        maskDown = new Vector2(0, (damage * bubbleUnit * -1));

        //Air Bubble Mask can move down to y: 0 before bubble is no longer visible
        bubbleMask.Translate(maskDown, gameObject.transform);
    }
}
