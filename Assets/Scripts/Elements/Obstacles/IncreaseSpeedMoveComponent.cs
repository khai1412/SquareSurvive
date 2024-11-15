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
        private void Start()
        {
            OnValidate();
        }
        public void OnValidate()
        {
            Vector2 size = GetComponent<SpriteRenderer>().size;
            GetComponent<BoxCollider2D>().size = size;
        }
    }
}