using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class Actor : MonoBehaviour
{
    public  ActorMovement movement;
    public  ActorColor    color;
    private void Start()
    {
        this.color.SetColor(GameConfig.data.colors.Random());
        this.movement.StartMove();
    }
    public void Die()
    {
        movement.Die();
        color.SetColor(Color.black);
    }
    private void OnValidate()
    {
        this.movement = this.GetComponent<ActorMovement>();
        this.color    = this.GetComponent<ActorColor>();
    }
}