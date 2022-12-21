using UnityEngine;

namespace Box
{
    public class Pushable : MonoBehaviour
    {
        [SerializeField] private LayerMask groundMask;
        private float groundDetectionDistance = 0.5f;
        private Vector3 halfSize;

        private void Awake()
        {
            float xSide = GetComponent<Collider2D>().bounds.extents.x;
            halfSize = new Vector3(xSide, 0f);
        }

        private void FixedUpdate()
        {
            if (IsGrounded()) return;
            transform.Translate(2.5f * Time.deltaTime * Vector2.down);
        }

        private bool IsGrounded()
        {
            RaycastHit2D leftHit = Physics2D.Raycast(transform.position - halfSize, Vector2.down, groundDetectionDistance, groundMask);
            RaycastHit2D rightHit = Physics2D.Raycast(transform.position + halfSize, Vector2.down, groundDetectionDistance, groundMask);
            return leftHit || rightHit;
        }
    }
}