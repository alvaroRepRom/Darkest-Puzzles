using System.Collections.Generic;

namespace Enemy.StateMachine
{
    public class StateFactory
    {
        private readonly EnemyController ctx;
        private readonly List<BaseState> states = new();

        public const int PATROL = 0;
        public const int ALERT = 1;
        public const int COMEBACK = 2;

        public StateFactory(EnemyController enemyController)
        {
            ctx = enemyController;
            states.Add(new Patrol(ctx, this));
            states.Add(new Alert(ctx, this));
            states.Add(new Comeback(ctx, this));
        }

        public BaseState SelectState(int stateIndex) { return states[stateIndex]; }
    }
}