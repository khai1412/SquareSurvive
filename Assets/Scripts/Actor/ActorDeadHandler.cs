using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorDeadHandler : ActorComponent
{
    [SerializeField] GameObject deadIcon;
    float stayTime;
    int count = 0;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MoveObstacle"))
        {
            stayTime += Time.deltaTime;
            if (stayTime > GameConfig.data.maxStayTime&&count>=2)
            {
                deadIcon.SetActive(true);
                actor.Die();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        count++;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        stayTime = 0;
        count--;
    }
}
