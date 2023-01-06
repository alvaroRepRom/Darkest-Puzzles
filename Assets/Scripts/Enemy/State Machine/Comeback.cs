using UnityEngine;

namespace Enemy.StateMachine
{
    public class Comeback : BaseState
    {
        public Comeback(EnemyController currentContext, StateFactory states) : base(currentContext, states) { }
        public override void EnterState()
        {
            ctx.SpriteRenderer.flipX = !ctx.StartFlipped;
            ctx.LookDirection = ctx.SpriteRenderer.flipX ? Vector2.left : Vector2.right;
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {
            LookForTarget();
            Move();
            ReturnToPatrolCondition();
        }

        private void LookForTarget()
        {
            Vector3 castPos = ctx.transform.position + ctx.CastRayOffset;
            RaycastHit2D hit = Physics2D.Raycast(castPos, ctx.LookDirection, ctx.WatchDistance, ctx.PlayerMask);
            if (hit)
            {
                ctx.XTarget = hit.point.x; // Search for last Player seen point
                SwitchState(ctx.States.SelectState(StateFactory.ALERT));
            }
        }
        private void Move() => ctx.transform.Translate(Time.deltaTime * ctx.PatrolSpeed * ctx.LookDirection);

        private void ReturnToPatrolCondition()
        {
            float distanceBetween = ctx.OriginalX - ctx.transform.position.x;

            if (ctx.SpriteRenderer.flipX) // goes left
                if (distanceBetween > 0)
                    SwitchState(ctx.States.SelectState(StateFactory.PATROL));

            if (!ctx.SpriteRenderer.flipX)// goes right
                if (distanceBetween < 0)
                    SwitchState(ctx.States.SelectState(StateFactory.PATROL));
        }
    }
}