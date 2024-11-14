namespace Elements.Obstacles
{
    using UnityEngine;

    public class DestroyAbleComponent : BaseActionBehaviour
    {
        public override void Execute(Collider2D col)
        {
            Destroy(this.gameObject);
        }
    }
}