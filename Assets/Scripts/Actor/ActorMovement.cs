using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorMovement : ActorComponent
{
    [SerializeField] Rigidbody2D rb;
    private          Vector2     direction;
    private          float       speed;
    public void StartMove()
    {
        speed          = GameConfig.data.initialSpeed;
        this.direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        rb.velocity    = direction * speed;
    }

    public void ChangeSpeed(float newSpeed)
    {
        this.speed  = this.speed + newSpeed >= 0 ? this.speed + newSpeed : 0;
        if (this.speed == 0)
        {
            this.Stop();
            return;
        }
        //rb.velocity = direction * speed;
    }
    public void Disable()
    {
        Stop();
        GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Stop()
    {
        speed       = 0;
        rb.velocity = Vector2.zero;
    }
    private void Update()
    {
        Move();
    }

    private void Move() { transform.Translate(this.direction * this.speed * Time.deltaTime); }
    private void OnCollisionEnter2D(Collision2D other)
    {
        this.direction = Vector2.Reflect(this.direction, other.contacts[0].normal);
        Debug.Log("Collide", other.gameObject);
    }

    public void SetDirection(Vector2 direction) { this.direction = direction; }

    public  void SetSpeed(float speed) { this.speed = speed; }
    private void OnValidate()          { rb         = GetComponent<Rigidbody2D>(); }
}