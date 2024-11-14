namespace Elements.Obstacles
{
    using UnityEngine;

    public abstract class BaseActionBehaviour : MonoBehaviour
    {
        public abstract void Execute(Collider2D col);
    }
}