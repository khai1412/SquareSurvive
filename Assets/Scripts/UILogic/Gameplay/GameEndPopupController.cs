namespace UILogic.Gameplay
{
    using System;
    using StateMachine;
    using StateMachine.States;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameEndPopupController : MonoBehaviour
    {
        public Button replayBtn;

        private void Awake()
        {
            this.replayBtn.onClick.AddListener(this.OnReplayBtnClick);
        }

        private void OnReplayBtnClick()
        {
            StateMachineManager.Instant.TransitionToState<GameHomeState>();
        }
    }
}