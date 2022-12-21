using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;

        private Rigidbody2D rb;
        private Animator anim;
        private SpriteRenderer sprite;
        private float horizontal;

        private const string HORIZONTAL = "Horizontal";

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sprite = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            horizontal = Input.GetAxis(HORIZONTAL);
            transform.Translate(Time.deltaTime * horizontal * speed * Vector2.right);
            anim.SetBool("IsWalking", horizontal != 0f);
            Flip();
        }

        private void Flip()
        {
            if (horizontal < 0f)
                sprite.flipX = true;
            else
            if (horizontal > 0f)
                sprite.flipX = false;
        }
    }
}