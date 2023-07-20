using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollision : EntityBehavior
{
    public void OnTriggerEnter2D()
    {
        EntityCollide();
        Debug.Log("ding");
    }


}
