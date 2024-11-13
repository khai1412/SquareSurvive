namespace StateMachine.States
{
    using UnityEngine;

    public class GameHomeState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter home state");
        }
        public void Exit()
        {
            Debug.Log("exit home state");
        }
    }
}