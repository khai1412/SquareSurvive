namespace StateMachine.States
{
    using Managers;
    using Model.LocalData.Base;
    using Model.LocalData.Data;
    using UILogic;
    using UnityEngine;

    public class GameHomeState : IState
    {
        public void Enter()
        {
            Debug.Log("Enter home state");
            UIManager.Instant.ActiveHomeScreen();
            var currentLevel = LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel;
            GenerateMapLevelManager.Instant.GenerateMapLevel(currentLevel);
            Time.timeScale = 0;
        }
        public void Exit()
        {
            Debug.Log("exit home state");
        }
    }
}