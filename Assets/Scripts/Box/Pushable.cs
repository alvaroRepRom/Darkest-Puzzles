using UnityEngine;

namespace Box
{
    public class Pushable : MonoBehaviour
    {
        [SerializeField] private LayerMask groundMask;

        private Rigidbody2D rb;
        private Vector3 halfSize;
        private const float groundDetectionDistance = 0.5f;
        private const float fallSpeed = 3f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            float xSide = GetComponent<Collider2D>().bounds.extents.x;
            halfSize = new Vector3(xSide, 0f);
        }

        private void Update()
        {
            if (IsGrounded()) return;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.MovePosition(rb.position + Time.deltaTime * fallSpeed * Vector2.down);
        }

        private bool IsGrounded()
        {
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position - halfSize, Vector2.down, groundDetectionDistance, groundMask);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position + halfSize, Vector2.down, groundDetectionDistance, groundMask);
            return leftHit || rightHit;
        }
    }
}