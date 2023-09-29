using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    Rigidbody2D rigidBody;
    SpriteRenderer fishSprite;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        fishSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigidBody)
            rigidBody.velocity = speed * Vector3.left * Time.deltaTime;

        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        speed *= -1;
        fishSprite.flipX = !fishSprite.flipX;
    }
}
