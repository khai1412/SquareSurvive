namespace StateMachine.States
{
    using Managers;
    using Model.LocalData.Base;
    using Model.LocalData.Data;

    public class GamePlayState : IState
    {
        public void Enter()
        {
            var currentLevel = LocalDataManager.Instant.GetLocalData<GameLocalData>().currentLevel;
            GenerateMapLevelManager.Instant.GenerateMapLevel(currentLevel);
        }
        public void Exit()
        {
            
        }
    }
}