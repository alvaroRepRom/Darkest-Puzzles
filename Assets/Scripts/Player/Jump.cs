using UnityEngine;

namespace Player
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] private float jumpForce = 3f;
        [SerializeField] private float groundDetectionDistance;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D rb;
        private Animator anim;
        private const KeyCode jumpKey = KeyCode.Space;
        private bool hasJump;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (IsGrounded() && Input.GetKey(jumpKey) && !hasJump)
            {
                hasJump = true;
                anim.SetTrigger(AnimatorVar.HAS_JUMP);
            }
        }

        private void FixedUpdate()
        {
            if (hasJump)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                hasJump = false;
            }
        }

        private bool IsGrounded()
        {
            bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDetectionDistance, groundMask);
            anim.SetBool(AnimatorVar.IS_GROUNDED, isGrounded);
            return isGrounded;
        }
    }
}