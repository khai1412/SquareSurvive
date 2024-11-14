namespace Elements.Obstacles
{
    using UnityEngine;

    public class TeleportFieldComponent : BaseActionBehaviour
    {
        public Transform target;
        public override void Execute(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                col.gameObject.transform.position = this.target.position;
            }
        }
    }
}