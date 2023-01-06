using UnityEngine;

namespace Enemy.StateMachine
{
    public class Alert : BaseState
    {
        public Alert(EnemyController currentContext, StateFactory states) : base(currentContext, states) { }
        public override void EnterState()
        {
            ctx.onAlertSO.OnAlert(true);
            ctx.EyeLight.enabled = true;
            ctx.Anim.SetBool(ctx.IS_MOVING, true);
            ctx.EyeLight.transform.eulerAngles = LightsRotation();
        }

        public override void ExitState()
        {
            ctx.onAlertSO.OnAlert(false);
            ctx.EyeLight.enabled = false;
        }

        public override void UpdateState()
        {
            LookForTarget();
            Move();
            ExitCondition();
        }

        private void LookForTarget()
        {
            Vector3 castPos = ctx.transform.position + ctx.CastRayOffset;
            RaycastHit2D hit = Physics2D.Raycast(castPos, ctx.LookDirection, ctx.WatchDistance, ctx.PlayerMask);
            if (hit) ctx.XTarget = hit.point.x; // Search for last Player seen point
        }
        private void Move() => ctx.transform.Translate(Time.deltaTime * ctx.AlertSpeed * ctx.LookDirection);

        private void ExitCondition()
        {
            float distanceBetween = ctx.XTarget - ctx.transform.position.x;

            if (ctx.SpriteRenderer.flipX) // goes left
                if (distanceBetween > 0)
                    SwitchState(ctx.States.SelectState(StateFactory.COMEBACK));

            if (!ctx.SpriteRenderer.flipX)// goes right
                if (distanceBetween < 0)
                    SwitchState(ctx.States.SelectState(StateFactory.COMEBACK));
        }

        private Vector3 LightsRotation()
        {
            Vector3 lightsRotation = new(0, 0, 90);
            return ctx.SpriteRenderer.flipX ? lightsRotation : -lightsRotation;
        }
    }
}