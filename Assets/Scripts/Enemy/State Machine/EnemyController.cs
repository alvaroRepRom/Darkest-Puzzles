using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemy.StateMachine
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private float watchDistance = 5f;
        [SerializeField] private float alertSpeed = 3.5f;
        [SerializeField] private float patrolSpeed = 1.5f;
        [SerializeField] private LayerMask playerMask;
        private Vector3 castRayOffset = new(0, 0.25f, 0);

        public Light2D EyeLight { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }
        public Animator Anim { get; private set; }
        public Vector3 CastRayOffset { get { return castRayOffset; } }
        public Vector2 LookDirection { get; set; }
        public float OriginalX { get; private set; }
        public float XTarget { get; set; }
        public bool StartFlipped { get; private set; }
        public float AlertSpeed { get { return alertSpeed; } }
        public float PatrolSpeed { get { return patrolSpeed; } }

        [HideInInspector]
        public string IS_MOVING = "IsMoving";
        public OnAlertSO onAlertSO;

        public BaseState CurrentState { get; set; }
        public StateFactory States { get; set; }
        public float WatchDistance { get { return watchDistance; } }
        public LayerMask PlayerMask { get { return playerMask; } }

        private void Awake()
        {
            InitComponents();
            InitFields();
            InitStateMachine();
        }
        private void Update() { CurrentState.UpdateState(); }

        private void InitComponents()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Anim = GetComponent<Animator>();
            EyeLight = GetComponentInChildren<Light2D>();
        }

        private void InitFields()
        {
            OriginalX = transform.position.x;
            StartFlipped = SpriteRenderer.flipX;
        }

        private void InitStateMachine()
        {
            States = new StateFactory(this);
            CurrentState = States.SelectState(StateFactory.PATROL);
            CurrentState.EnterState();
        }
    }
}