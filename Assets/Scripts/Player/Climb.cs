using UnityEngine;
using ARR.RigidbodyEX;

namespace Player
{
    public class Climb : MonoBehaviour
    {
        [SerializeField] private float climbSpeed = 3f;
        [SerializeField] private LayerMask stairsMask;

        private Rigidbody2D rb;
        private Animator anim;
        private Vector3 halfSide = new(0.3f, 0);

        private const string VERTICAL = "Vertical";

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            if (HasDied()) return;
            float vertical = Input.GetAxis(VERTICAL);            
            if (IsOnStairs())
            {
                rb.gravityScale = 0f;
                rb.VelY(0f);
                anim.speed = 0;
                if (vertical != 0f)
                {
                    transform.Translate(Time.deltaTime * vertical * climbSpeed * Vector2.up);
                    IsClimbing(true);
                }
            }
            else
            {
                rb.gravityScale = 1f;
                IsClimbing(false);
            }
        }

        private bool IsOnStairs()
        {
            RaycastHit2D leftHit  = Physics2D.Raycast(transform.position - halfSide, Vector2.zero, 0f, stairsMask);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position + halfSide, Vector2.zero, 0f, stairsMask);
            return leftHit && rightHit;
        }

        private void IsClimbing(bool isClimbing)
        {
            anim.speed = 1;
            anim.SetBool(AnimatorVar.IS_CLIMBING, isClimbing);
        }

        private bool HasDied()
        {
            return anim.GetCurrentAnimatorStateInfo(0).IsName(AnimatorVar.PLAYER_DEATH);
        }
    }
}