namespace Elements.Obstacles
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Collider2D))]
    public sealed class ObstacleActor : MonoBehaviour
    {
        public List<BaseActionBehaviour> listBehaviourExecuteOnStart;
        public List<BaseActionBehaviour> listBehaviourExecuteOnTriggerEnter;
        public List<BaseActionBehaviour> listBehaviourExecuteOnColliderEnter;
        private void Start()
        {
            this.listBehaviourExecuteOnStart.ForEach(e=>e.Execute(null));
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            //Debug.Log("OnTrigger",gameObject);
            this.listBehaviourExecuteOnTriggerEnter.ForEach(e=>e.Execute(col));
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            this.listBehaviourExecuteOnColliderEnter.ForEach(e=>e.Execute(col.collider));
        }
    }
}