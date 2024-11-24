using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using UnityEngine;

[RequireComponent(typeof(ActorMovement))]
public class Actor : MonoBehaviour
{
    public  ActorMovement movement;
    public  ActorColor    color;
    private void Start()
    {
        this.movement.StartMove();
    }
    public async void Die()
    {
        movement.Disable();
        color.SetColor(Color.black);
        await Task.Delay(TimeSpan.FromSeconds(0.5f));
        GenerateMapLevelManager.Instant.currentMapLevel.RemoveActor(this);
        Destroy(this.gameObject);

    }
    
    private void OnValidate()
    {
        this.movement = this.GetComponent<ActorMovement>();
        this.color    = this.GetComponent<ActorColor>();
    }

    public void Finish()
    {
        movement.Disable();
        color.Finish();
        //do something better here
        Debug.Log("Finish");
    }
}