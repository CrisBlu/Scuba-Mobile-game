using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int score = 0;

    public void PlayerCollide()
    {
        score += 1;
    }



}



