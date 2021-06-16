using System.Collections.Generic;
using Animators;
using Characters;
using Characters.Armour;
using Characters.Attack;
using Characters.Damage;
using Characters.Health;
using Characters.Hurtbox;
using Characters.Movement;
using General.Util;
using Player.MovementDirection;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Stats))]
    public class Player : MonoBehaviour, IPlayer, IDamageDealer
    {
        private static readonly FastEnumIntEqualityComparer<MovementEnum> FastEnumIntEqualityComparer =
            new FastEnumIntEqualityComparer<MovementEnum>();

        private readonly Dictionary<MovementEnum, IMovement> _movements =
            new Dictionary<MovementEnum, IMovement>(FastEnumIntEqualityComparer);

        private IMovement _movement;
        private IAnimatorFacade _animatorFacade;
        private IMovementDirection _movementDirection;
        private IHealthComponent _healthComponent;
        private IArmour _armour;
        private IAttackManager _attackManager;
        private Rigidbody _rbd;
        private Stats _stats;

        [SerializeField] private CameraView cameraView;


        private void Start()
        {
            _rbd = GetComponent<Rigidbody>();
            _stats = GetComponent<Stats>();
            _movementDirection = SetCameraDirection(cameraView);
            _animatorFacade = new AnimatorFacade(GetComponentInChildren<ICharacterAnimator>(), this);
            InitMovements(); // creating all movements
            _movement = _movements[MovementEnum.Ground]; // setting the current movement as Ground One
            _healthComponent = new HealthComponent(this);
            _armour = new Armour(this);
            _attackManager = new AttackManager(_animatorFacade, this);
        }

        private void FixedUpdate()
        {
            _movement.Move(_movementDirection.GetDirection());
        }


        public void Die()
        {
        }


        private IMovementDirection SetCameraDirection(CameraView cameraView)
        {
            this.cameraView = cameraView;
            return cameraView switch
            {
                CameraView.AlwaysForward => new ThirdPersonCameraDirection(),
                _ => new ThirdPersonCameraDirection()
            };
        }

        public IHealthComponent getHealthComponent()
        {
            return _healthComponent;
        }

        public IAnimatorFacade getAnimatorFacade()
        {
            return _animatorFacade;
        }

        public IArmour getArmour()
        {
            return _armour;
        }

        public IAttackManager getAttackManager()
        {
            return _attackManager;
        }

        public Rigidbody getRigidbody()
        {
            return _rbd;
        }

        public Transform getTransform()
        {
            return transform;
        }

        public IMovement getMovement()
        {
            return _movement;
        }

        public void ChangeMovement(MovementEnum movementEnum)
        {
            // Movement states life cycles
            _movement.CleanUp(); // cleaning up the current movement
            _movement = _movements[movementEnum]; // changing the current movement to the new one
            _movement.SetUp(); // setting up new movement
        }

        public Stats getStats()
        {
            return _stats;
        }

        public void ChangeMovementDirection(IMovementDirection movementDirection)
        {
            this._movementDirection = movementDirection;
        }

        public void ChangeMovementDirection(CameraView cameraView)
        {
            _movementDirection = SetCameraDirection(cameraView);
        }

        /// <summary>
        /// Creating <b>ALL POSSIBLE</b> movements at the Start
        /// That way we don't need to create a new movement each time we change the movement state
        /// We can just use movements[MovementEnum] to get each movement
        /// We are using this array in changeMovement(MovementEnum)
        /// </summary>
        private void InitMovements()
        {
            _movements.Add(MovementEnum.Ground, new GroundMovement(this));
            _movements.Add(MovementEnum.Midair, new MidairMovement(this));
            _movements.Add(MovementEnum.Crouch, new CrouchingMovement(this));
            _movements.Add(MovementEnum.Slide, new SlidingMovement(this));
            _movements.Add(MovementEnum.Attack, new AttackingMovement(this));
        }

        public void DealDamage(IHurtbox hurtbox)
        {
            _attackManager.DealDamage(hurtbox);
        }
    }
}