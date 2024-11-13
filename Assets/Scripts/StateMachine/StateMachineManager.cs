namespace StateMachine
{
    using System;
    using System.Collections.Generic;
    using Extension;

    public class StateMachineManager : Singleton<StateMachineManager>
    {
        private readonly Dictionary<Type, IState> states = new();
        private          IState                   currentState;

        public StateMachineManager()
        {
            var allState = ReflectionExtension.GetAllClassThatDeliverType<IState>();
            allState.ForEach(state=> this.states.Add(state, Activator.CreateInstance(state) as IState));
        }
        
        public void TransitionToState<T>() where T : IState
        {
            if (this.currentState != null)
            {
                this.currentState.Exit();
                this.currentState = null;
            }

            var nextState = this.states[typeof(T)];
            nextState.Enter();
        }
    }
}