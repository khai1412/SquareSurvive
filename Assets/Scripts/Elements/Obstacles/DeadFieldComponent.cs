namespace Elements.Obstacles
{
    using UnityEngine;

    public class DeadFieldComponent : BaseActionBehaviour
    {
        public override void Execute(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var actor = col.GetComponent<Actor>();
                actor.Die();
            }
        }
    }
}