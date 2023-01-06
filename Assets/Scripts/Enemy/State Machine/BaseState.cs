namespace Enemy.StateMachine
{
    public abstract class BaseState
    {
        protected EnemyController ctx;
        protected StateFactory states;

        public BaseState(EnemyController currentContext, StateFactory states)
        {
            ctx = currentContext;
            this.states = states;
        }
        public abstract void EnterState();
        public abstract void ExitState();
        public abstract void UpdateState();
        protected void SwitchState(BaseState newState)
        {
            ctx.CurrentState.ExitState();
            newState.EnterState();
            ctx.CurrentState = newState;
        }
    }
}