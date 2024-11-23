namespace StateMachine.States
{
    using Managers;
    using Model.LocalData.Base;
    using Model.LocalData.Data;
    using UILogic;
    using UnityEngine;

    public class GamePlayState : IState
    {
        public void Enter()
        {
            Time.timeScale = 1;
            UIManager.Instant.ActiveGameplayScreen();
        }
        public void Exit()
        {
            
        }
    }
}