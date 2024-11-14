namespace Elements.Obstacles
{
    using System.Collections.Generic;
    using System.Linq;
    using DG.Tweening;
    using DG.Tweening.Plugins.Core.PathCore;
    using UnityEngine;

    public class MoveAbleComponent : BaseActionBehaviour
    {
        public List<Transform> pathMove  = new();
        public float           speedMove = 5;

        private float GetTotalTimeToMove()
        {
            if (this.pathMove.Count < 2) return 0;
            float totalDistance = 0;
            for (int i = 0; i < this.pathMove.Count - 1; i++)
            {
                totalDistance += Vector2.Distance(this.pathMove[i].position, this.pathMove[i + 1].position);
            }

            return totalDistance;
        }
        public override void Execute(Collider2D col)
        {
            DOTween.Kill(this.transform);
            var wayPoint             = this.pathMove.Select(e => e.position).ToArray();
            var timeToMoveFinishPath = this.GetTotalTimeToMove() / this.speedMove;
            this.transform.DOPath(new Path(PathType.Linear, wayPoint, 0), timeToMoveFinishPath).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        }
    }
}