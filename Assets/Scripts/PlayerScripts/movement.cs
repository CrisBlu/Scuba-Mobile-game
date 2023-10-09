using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class movement : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public float MAX_SPEED;
    public float FALL_SPEED;
    public float acceleration;
    public float decceleration;
    public bool falling;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;


    public Vector2 speed;
    Vector2 direction;
    Vector2 height;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        speed = new Vector2(0, 0);
        falling = true;
    }

    void FixedUpdate()
    {


        //If a touch is detected
        if (Input.touchCount > 0)
        {
            animator.SetBool("Walking", true);
            //Is speed less than MAX_SPEED? then add acceleration to speed, if not then speed is equal to MAX_SPEED
            
            

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            

            //Get whether the touch was on the left or right side of the screen and set direction 

            //If touch is on left side of screen, set direction to -1; if touch is on right side of the screen set direction to 1
            //direction = new Vector2(0f, 0f);
            direction.x = ((Screen.width / 2) - touchPosition.x > 0) ? -1 : 1;

            if(direction.x == -1){
                sprite.flipX = true;
            }else if(direction.x == 1){
                sprite.flipX = false;
            }

            //Calculate intended speed
            speed = CalculateSpeed(speed, direction.x);
            

        }
    else
        {
            //Slide to a stop; pull speed to 0 when no direction is selected
            
            if (speed.x > 0f) //If speed is greater than 0
            {
                //Decrease Speed by decceleration
                speed.x = speed.x - decceleration;
            }
            else if (speed.x < 0f) //If speed is less than 0
            {
                //Increase Speed by decceleration
                speed.x = speed.x + decceleration;
            }

            animator.SetBool("Walking", false);


                 
        }


        //Apply speed to rigidbody
        rigidBody.velocity = (speed * Time.deltaTime);
    
        
    }


    Vector2 CalculateSpeed(Vector2 speed, float direction){
        float motion;

        if (falling)
        {
            //Motion is noted as the absolute value of speed
            motion = Mathf.Abs(speed.x);
            
            //Is motion less than MAX_SPEED? then add acceleration to motion, if not then motion is equal to MAX_SPEED
            motion = (motion < MAX_SPEED) ? motion + acceleration : MAX_SPEED;

            //Create vector with motion as x
            speed = new Vector2(motion * direction, 0f);
        }
        else
        {
            //Motion is noted as equal to speed
            motion = speed.x;

            //Motion increases by acceleration times direction, this allows for a non instant turn
            motion += acceleration * direction;

            //If the absolute value of motion goes over the max speed, motion is max speed in the right direction; otherwise it's just motion = motion
            motion = (Mathf.Abs(motion) > MAX_SPEED) ? MAX_SPEED * direction: motion;

            //Create vector with motion as x
            speed = new Vector2(motion, 0f);
        }
     
        return speed;
    }

    public void RiseUp(){
        rigidBody.gravityScale *= -1;
        falling = false;
    }
        
    

}
