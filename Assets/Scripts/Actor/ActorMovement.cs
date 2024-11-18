using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActorMovement : ActorComponent
{
    Vector2 direction;
    private float speed;
    public void StartMove()
    {
        speed = GameConfig.data.initialSpeed;
        direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    public async void ChangeSpeed(float newSpeed)
    {
        speed += newSpeed;
        await Task.Delay(3000);
        speed = GameConfig.data.initialSpeed;
    }
    public void Disable()
    {
        Stop();
        GetComponent<Collider2D>().enabled = false;
    }
    public void Stop()
    {
        speed = 0;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(this.direction * this.speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{

        //}
        //else
            this.direction = Vector2.Reflect(this.direction, other.contacts[0].normal);
        //Debug.Log("Collide", other.gameObject);
    }
}