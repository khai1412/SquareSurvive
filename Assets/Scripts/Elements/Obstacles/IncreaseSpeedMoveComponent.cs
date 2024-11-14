namespace Elements.Obstacles
{
    using UnityEngine;

    public class IncreaseSpeedMoveComponent : BaseActionBehaviour
    {
        public float additionSpeed;
        public override void Execute(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var actor = col.GetComponent<Actor>();
                actor.movement.ChangeSpeed(this.additionSpeed);
            }
        }
    }
}