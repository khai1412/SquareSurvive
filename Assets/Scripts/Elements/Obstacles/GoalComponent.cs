using Elements.Obstacles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalComponent : BaseActionBehaviour
{
    public override void Execute(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            var actor = col.GetComponent<Actor>();
            actor.Finish();
        }
    }

}
