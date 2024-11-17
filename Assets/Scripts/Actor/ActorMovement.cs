using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ActorMovement : ActorComponent
{
    [SerializeField] Rigidbody2D rb;
    //Vector2 direction;
    private          float       speed;
    public void StartMove()
    {
        speed          = GameConfig.data.initialSpeed;
        Vector2 direction = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        rb.velocity    = direction * speed;
    }

    public async void ChangeSpeed(float newSpeed)
    {
        //this.speed  = this.speed + newSpeed >= 0 ? this.speed + newSpeed : 0;
        //if (this.speed == 0)
        //{
        //    this.Stop();
        //    return;
        //}
        if (rb.velocity.magnitude > 40) return;
        rb.velocity *= ((speed + newSpeed) / speed);
        speed += newSpeed;
        await Task.Delay(3000);
        speed = GameConfig.data.initialSpeed;
        rb.velocity= rb.velocity.normalized * speed;
        //rb.velocity = direction * speed;
    }
    public void Disable()
    {
        Stop();
        GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Stop()
    {
        speed = 0;
        //DOVirtual.Float(speed, 0, 0.25f, x => { speed = x; }).SetEase(Ease.OutSine);
        rb.velocity = Vector2.zero;
    }
    private void Update()
    {
        //Move();
    }

    private void Move() { 
        //transform.Translate(this.direction * this.speed * Time.deltaTime); 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
         //this.direction = Vector2.Reflect(this.direction, other.contacts[0].normal);
        //Debug.Log("Collide", other.gameObject);
    }

    private void OnValidate()          { rb         = GetComponent<Rigidbody2D>(); }
}