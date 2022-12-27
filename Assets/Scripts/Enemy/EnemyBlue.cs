using UnityEngine;
using UnityEngine.Rendering.Universal;
using ARR.TransformEX;

namespace Enemy
{
    public class EnemyBlue : MonoBehaviour
    {
        [SerializeField] private float watchDistance = 5f;
        [SerializeField] private LayerMask playerMask;
        
        private Light2D eyeLight;
        private SpriteRenderer spriteRenderer;
        private Animator anim;
        private Vector2 lookDirection;
        private float originalX;
        private float xTarget;
        private bool startFlipped;
        private bool isAlert;
        private bool isPatrol = true;

        private const float alertSpeed = 3.2f;
        private const float patrolSpeed = 1.5f;
        private const string IS_MOVING = "IsMoving";

        public OnAlertSO onAlertSO;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            eyeLight = GetComponentInChildren<Light2D>();
            originalX = transform.position.x;
            startFlipped = spriteRenderer.flipX;
        }
        
        private void Update()
        {
            Patrol();

            anim.SetBool(IS_MOVING, !isPatrol);

            OnAlert();
            Comeback();
        }

        private void Patrol()
        {
            lookDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, watchDistance, playerMask);

            if (hit)
            {
                if (!isAlert && isPatrol)
                {
                    onAlertSO.OnAlert(true);
                    isAlert = true;
                    isPatrol = false;
                    eyeLight.enabled = true;
                }
                xTarget = hit.point.x; // Search for last Player seen point
            }
        }

        private void OnAlert()
        {
            if (!isAlert) return;
            if (transform.position.x != xTarget)
                transform.Translate(Time.deltaTime * alertSpeed * lookDirection);
            else
            {
                isAlert = false;
                spriteRenderer.flipX = !startFlipped;
                eyeLight.enabled = false;
            }
        }

        private void Comeback()
        {
            if (isAlert) return;
            if (isPatrol) return;
            if (transform.position.x != originalX)
            {
                spriteRenderer.flipX = !startFlipped;
                transform.Translate(Time.deltaTime * patrolSpeed * lookDirection);

                if (spriteRenderer.flipX)
                {
                    if (transform.position.x < originalX)
                        transform.X(originalX);
                }
                else
                {
                    if (transform.position.x > originalX)
                        transform.X(originalX);
                }
            }
            else
            {
                spriteRenderer.flipX = startFlipped;
                if (!isPatrol)
                    onAlertSO.OnAlert(false);
                isPatrol = true;
            }
        }
    }
}