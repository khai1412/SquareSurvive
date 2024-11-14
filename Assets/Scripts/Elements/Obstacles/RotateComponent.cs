namespace Elements.Obstacles
{
    using DG.Tweening;
    using UnityEngine;

    public class RotateComponent : BaseActionBehaviour
    {
        public float rotateSpeed = 5;
        public override void Execute(Collider2D col)
        {
            transform.DORotate(new Vector3(0, 0, 360), 10 / this.rotateSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Restart);
        }
    }
}