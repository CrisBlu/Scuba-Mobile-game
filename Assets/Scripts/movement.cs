using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float MAX_SPEED;
    public float FALL_SPEED;
    public float acceleration;
    public float decceleration;


    public float speed;
    bool falling = true;
    Vector2 direction;
    Vector2 height;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = 0;
}

    void FixedUpdate()
    {
        //falling
        if (falling == true)
        {
            //direction.y = -1;
            
        }


        //May change to MoveVelocity later
        //If a touch is detected
        if (Input.touchCount > 0)
        {
            //Is speed less than MAX_SPEED? then add 1 to speed, if not then speed is equal to MAX_SPEED
            speed = (speed < MAX_SPEED) ? speed+acceleration : MAX_SPEED;

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            //Get whether the touch was on the left or right side of the screen and set direction 

            //If touch is on left side of screen, set direction to -1; if touch is on right side of the screen set direction to 1
            //direction = new Vector2(0f, 0f);
            direction.x = ((Screen.width / 2) - touchPosition.x > 0) ? -1 : 1;

        }
        else
        {
            //Slide to a stop
            speed = (speed > 0f) ? speed - decceleration : 0f;
                 
        }

        rigidBody.MovePosition(rigidBody.position + direction * Time.deltaTime * speed);
    }
}
