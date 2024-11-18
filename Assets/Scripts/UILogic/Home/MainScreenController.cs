namespace UILogic.Home
{
    using StateMachine;
    using StateMachine.States;
    using UnityEngine;
    using UnityEngine.UI;

    public class MainScreenController : MonoBehaviour
    {
        public  Button playBtn;
        private void Awake()
        {
            this.playBtn.onClick.AddListener(this.OnClickPlay);
        }

        private void OnClickPlay()
        {
            StateMachineManager.Instant.TransitionToState<GamePlayState>();
        }
        
    }
}