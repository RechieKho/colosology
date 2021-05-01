using General.Movement;
using UnityEngine;
using General.Other;
using General.Coroutine;
using General.Attack;

namespace Specific.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Move")]
        public ForcePrec_SO move;
        [Header("dash")]
        public ImpactPrec_SO dash;
        public float dashDuration;
        public float dashCoolDown;
        [Header("Jump")]
        public ImpactPrec_SO jump;
        [Header("Floor Detection")]
        public Transform detectionPoint;
        public float radius;
        public LayerMask detectionLayer;
        [Header("Attack")]
        public MeleeCirc_SO attack;

        [HideInInspector]
        public MController mController;
        [HideInInspector]
        public ColliderDetection2D floorDetection;
        [HideInInspector]
        public ColliderDetection2D enemyDetection;
        [HideInInspector]
        public CooldownCounter dashCDCounter;
        [HideInInspector]
        public MeleeCircAtk attacker;

        public State state = new State();
        private PlayerStateBase _currentState;

        private void Awake()
        {
            mController = new MController(GetComponent<Rigidbody2D>(), true);
            floorDetection = new ColliderDetection2D(detectionPoint, radius, detectionLayer);
            enemyDetection = new ColliderDetection2D(gameObject.transform, attack.radius, attack.targetLayer);
            dashCDCounter = new CooldownCounter(dashCoolDown, Timer.Timing.unscaledTime); // can be adjustable
            attacker = new MeleeCircAtk(attack, gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {
            To(state.idleState);
        }

        // Update is called once per frame
        void Update()
        {
            _currentState.OnUpdate(this);
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedUpdate(this);
        }

        // Transition To
        public void To(PlayerStateBase __state)
        {
            _currentState?.OnExit(this);
            _currentState = __state;
            _currentState.OnEnter(this);
        }

        #region SubClass
        public class State
        {
            public readonly PlayerIdleState idleState = new PlayerIdleState();
            public readonly PlayerWalkState walkState = new PlayerWalkState();
            public readonly PlayerOnAirState onAirState = new PlayerOnAirState();
            public readonly PlayerDashState dashState = new PlayerDashState();
            public readonly PlayerJumpState jumpState = new PlayerJumpState();
        }

        public class CooldownCounter
        {
            private float _coolDownTime;
            private bool _isCoolDown;
            private Timer.Timing _timing;

            public bool IsCoolDown { get { return _isCoolDown; } }

            public CooldownCounter(float __coolDownTime, Timer.Timing __timing)
            {
                _coolDownTime = __coolDownTime;
                _timing = __timing;
            }

            public void StartCooldown()
            {
                if (_isCoolDown) return;
                _isCoolDown = true;
                new Timer(_timing, _coolDownTime, false, isFreezable: true, timeOut: () =>
                {
                    _isCoolDown = false;
                });
            }
        }
        #endregion
    }
}

