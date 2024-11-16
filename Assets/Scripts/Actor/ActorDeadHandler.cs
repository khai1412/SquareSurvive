using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDeadHandler : ActorComponent
{
    [SerializeField] GameObject deadIcon;
    float stayTime;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MoveObstacle"))
        {
            stayTime += Time.deltaTime;
            if (stayTime > GameConfig.data.maxStayTime)
            {
                deadIcon.SetActive(true);
                actor.Die();
            }
        }
    }
}
