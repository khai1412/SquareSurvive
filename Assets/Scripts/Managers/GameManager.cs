namespace Managers
{
    using StateMachine;
    using StateMachine.States;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            StateMachineManager.Instant.TransitionToState<GameHomeState>();
        }
    }
}