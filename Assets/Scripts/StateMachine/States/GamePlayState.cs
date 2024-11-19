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
            MidiController.index = 0;
            var currentLevel = LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel;
            GenerateMapLevelManager.Instant.GenerateMapLevel(currentLevel);
            UIManager.Instant.ActiveGameplayScreen();
        }
        public void Exit()
        {
            
        }
    }
}