using Elements.Obstacles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneComponent : BaseActionBehaviour
{
    public override void Execute(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GetComponent<Actor>().Die();
        }
    }
}
