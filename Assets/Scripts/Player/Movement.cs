using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3f;
        [Header("Pushing")]
        [SerializeField] private float pushingSpeed = 1.5f;
        [SerializeField] private LayerMask pushableMask;

        private Animator anim;
        private SpriteRenderer sprite;
        private float horizontal;
        private const float pushingRayDistance = 0.5f;

        private const string HORIZONTAL = "Horizontal";

        private void Awake()
        {
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (HasDied()) return;
            horizontal = Input.GetAxisRaw(HORIZONTAL);
            Flip();
            Animation();
            Move();
        }

        private void Move() => transform.Translate(Time.deltaTime * horizontal * Speed() * Vector2.right);
        private void Animation() => anim.SetBool(AnimatorVar.IS_WALKING, horizontal != 0f);

        private void Flip()
        {
            if (horizontal < 0f)
                sprite.flipX = true;
            else
            if (horizontal > 0f)
                sprite.flipX = false;
        }

        private float Speed()
        {
            bool isPushing = Physics2D.Raycast(transform.position, new Vector2(horizontal, 0f), pushingRayDistance, pushableMask);
            return isPushing ? pushingSpeed : moveSpeed;
        }

        private bool HasDied()
        {
            return anim.GetCurrentAnimatorStateInfo(0).IsName(AnimatorVar.PLAYER_DEATH);
        }
    }
}