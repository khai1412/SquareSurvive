namespace Elements.Obstacles
{
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(Collider2D))]
    public sealed class ObstacleActor : MonoBehaviour
    {
        public List<BaseActionBehaviour> listBehaviourExecuteOnStart;
        public List<BaseActionBehaviour> listBehaviourExecuteOnTriggerEnter;
        private void Start()
        {
            this.listBehaviourExecuteOnStart.ForEach(e=>e.Execute(null));
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            this.listBehaviourExecuteOnTriggerEnter.ForEach(e=>e.Execute(col));
        }
       
    }
}