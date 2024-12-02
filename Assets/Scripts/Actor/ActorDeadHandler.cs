using UnityEngine;

public class ActorDeadHandler : ActorComponent
{
    [SerializeField] GameObject deadIcon;

    private void LateUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one, 0, -1);
        if (hits.Length >= 3)
        {
            foreach(var hit in hits)
            {
                if(hit.CompareTag("MoveObstacle"))
                {
                    deadIcon.SetActive(true);
                    actor.Die();
                    return;
                }
            }
        }
    }

}
