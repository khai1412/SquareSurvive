namespace StateMachine.States
{
    using Managers;
    using Model.LocalData.Base;
    using Model.LocalData.Data;
    using UILogic;
    using UnityEngine;

    public class GameEndState : IState
    {
        public void Enter()
        {
            Time.timeScale = 0;
            UIManager.Instant.ActiveGameEndScreen();
            GenerateMapLevelManager.Instant.currentMapLevel.StopGame();

            var currentLevel = ++LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel;

            if (currentLevel >= 2) LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel = 1;
        }
        public void Exit() { }
    }
}