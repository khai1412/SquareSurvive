using System.Threading.Tasks;
using UnityEngine;

public class ActorMovement : ActorComponent
{
    Vector2                     direction;
    private               float speed;
    [Range(-1f, 1f)] public float startDirectionX;
    [Range(-1f, 1f)] public float startDirectionY;
    public                bool  isRandom;
    public void StartMove()
    {
        speed     = GameConfig.data.initialSpeed;
        direction = this.isRandom ? new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized : new Vector2(this.startDirectionX, this.startDirectionY).normalized;
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
        // GetComponent<Collider2D>().enabled = false;
    }
    public  void Stop()        { speed = 0; }
    private void FixedUpdate() { Move(); }

    private void Move() { transform.Translate(this.direction * this.speed * Time.fixedDeltaTime); }
    private void LateUpdate()
    {
        isCollide = false;
    }
    bool isCollide = false;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isCollide) return;
        isCollide = true;
        this.direction = Vector2.Reflect(this.direction, other.contacts[0].normal);
    }
}