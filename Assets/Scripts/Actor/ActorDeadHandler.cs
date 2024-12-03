using UnityEngine;

public class ActorDeadHandler : ActorComponent
{
    [SerializeField] GameObject deadIcon;
    float time = 0;
    private void LateUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0, -1);
        if (hits.Length >= 3)
        {
            time += Time.deltaTime;
            foreach(var hit in hits)
            {
                if(hit.CompareTag("MoveObstacle")&&time>GameConfig.data.maxStayTime)
                {
                    deadIcon.SetActive(true);
                    actor.Die();
                    return;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        time = 0;
    }
}
