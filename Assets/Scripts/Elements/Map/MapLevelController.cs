namespace Elements.Map
{
    using System.Collections.Generic;
    using System.Linq;
    using StateMachine;
    using StateMachine.States;
    using UnityEngine;

    public class MapLevelController : MonoBehaviour
    {
        public List<Actor> currentActors = new();
        public SpriteRenderer bound;
        public void RemoveActor(Actor actor)
        {
            if(!this.currentActors.Contains(actor)) return;
            this.currentActors.Remove(actor);
            if(this.currentActors.Count == 0) StateMachineManager.Instant.TransitionToState<GameEndState>();
        }
        void Start()
        {
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float targetRatio = bound.bounds.size.x / bound.bounds.size.y;

            if (screenRatio >= targetRatio)
            {
                Camera.main.orthographicSize = bound.bounds.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                Camera.main.orthographicSize = bound.bounds.size.y / 2 * differenceInSize;
            }
        }
        private void Awake()
        {
            currentActors=GetComponentsInChildren<Actor>().ToList();
            for (int i = 0; i < currentActors.Count; i++)
            {
                Actor actor = currentActors[i];
                actor.color.SetColor(GameConfig.data.colors[i]);
            }
        }
        public void StopGame() //khi 1 trong các 🟥 đi vào khu vực 🏁 đích, dừng màn hình? la timescale=0 hay stop all square
        {
            foreach(var actor in currentActors)
            {
                actor.movement.Stop();
            }
        }

    }
}