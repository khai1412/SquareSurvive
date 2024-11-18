namespace StateMachine.States
{
    using UILogic;
    using UnityEngine;

    public class GameHomeState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter home state");
            UIManager.Instant.ActiveHomeScreen();
            Time.timeScale = 0;

        }
        public void Exit()
        {
            Debug.Log("exit home state");
        }
    }
}