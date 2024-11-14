using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDeadDetection : ActorComponent
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            actor.Die();
        }
    }
}
