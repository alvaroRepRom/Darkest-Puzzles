using UnityEngine;
using ARR.TransformEX;

namespace Enemy.StateMachine
{
    public class Patrol : BaseState
    {
        public Patrol(EnemyController currentContext, StateFactory states) : base(currentContext, states) { }

        public override void EnterState()
        {
            ctx.SpriteRenderer.flipX = ctx.StartFlipped;
            ctx.LookDirection = ctx.SpriteRenderer.flipX ? Vector2.left : Vector2.right;
            ctx.transform.X(ctx.OriginalX);
            ctx.Anim.SetBool(ctx.IS_MOVING, false);
        }
        public override void ExitState() { }
        public override void UpdateState()
        {
            Vector3 castPos = ctx.transform.position + ctx.CastRayOffset;
            RaycastHit2D hit = Physics2D.Raycast(castPos, ctx.LookDirection, ctx.WatchDistance, ctx.PlayerMask);
            if (hit)
            {
                ctx.XTarget = hit.point.x; // Search for last Player seen point
                SwitchState(ctx.States.SelectState(StateFactory.ALERT));
            }
        }
    }
}