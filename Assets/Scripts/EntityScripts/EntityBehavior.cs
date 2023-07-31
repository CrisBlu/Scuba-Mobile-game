using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehavior : MonoBehaviour
{
    PlayerCollision PlayerCollisionScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCollisionScript = GameObject.Find("Hero").GetComponent<PlayerCollision>();
    }

    protected void EntityCollide(){
        PlayerCollisionScript.PlayerScore();
        Destroy(gameObject);
    }
}
