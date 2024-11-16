using Elements.Obstacles;
using Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalComponent : BaseActionBehaviour
{
    public override void Execute(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var actor = col.GetComponent<Actor>();
            actor.Finish();
            GenerateMapLevelManager.Instant.currentMapLevel.StopGame();
        }
    }
    private void Start()
    {
        OnValidate();
    }
    public void OnValidate()
    {
        Vector2 size = GetComponent<SpriteRenderer>().size;
        GetComponent<BoxCollider2D>().size = size;
    }
}
