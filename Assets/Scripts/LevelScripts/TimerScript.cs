using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float timerInSeconds;
    public Transform bubbleMask;


    //Equal to 100/Timer in Seconds; Tells the script how much of the bubble gets taken away
    //each timer tick
    float bubbleUnit;

    //Vector to send the Sprite Mask down
    Vector2 maskDown;

    
    void Start()
    {

        //Calculate the Bubble Unit
        bubbleUnit = 1/timerInSeconds;

        //Set the Vector
        maskDown = new Vector2(0, -1 * bubbleUnit);

    }

    
    void Update()
    {
        //Count the timer down
        if(timerInSeconds > 0)
        {
            timerInSeconds -= Time.deltaTime;

            //Air Bubble Mask can move down to y: -1 before bubble is no longer visible
            bubbleMask.Translate(maskDown * Time.deltaTime, gameObject.transform);
            
        }
    }
}
