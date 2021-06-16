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

        private readonly Dictionary<MovementEnum, IMovement> movements =
            new Dictionary<MovementEnum, IMovement>(FastEnumIntEqualityComparer);

        private IMovement movement;
        private IAnimatorFacade animatorFacade;
        private IMovementDirection movementDirection;
        private IHealthComponent healthComponent;
        private IArmour armour;
        private IAttackManager attackManager;
        private Rigidbody rbd;
        private Stats stats;

        [SerializeField] private CameraView cameraView;


        private void Start()
        {
            rbd = GetComponent<Rigidbody>();
            stats = GetComponent<Stats>();
            movementDirection = setCameraDirection(cameraView);
            animatorFacade = new AnimatorFacade(GetComponentInChildren<ICharacterAnimator>(), this);
            initMovements(); // creating all movements
            movement = movements[MovementEnum.Ground]; // setting the current movement as Ground One
            healthComponent = new HealthComponent(this);
            armour = new Armour(this);
            attackManager = new AttackManager(animatorFacade, this);
        }

        private void FixedUpdate()
        {
            movement.move(movementDirection.getDirection());
        }


        public void die()
        {
        }


        private IMovementDirection setCameraDirection(CameraView cameraView)
        {
            this.cameraView = cameraView;
            switch (cameraView)
            {
                case CameraView.AlwaysForward:
                    return new ThirdPersonCameraDirection();
                default:
                    return new ThirdPersonCameraDirection();
            }
        }

        public IHealthComponent getHealthComponent()
        {
            return healthComponent;
        }

        public IAnimatorFacade getAnimatorFacade()
        {
            return animatorFacade;
        }

        public IArmour getArmour()
        {
            return armour;
        }

        public IAttackManager getAttackManager()
        {
            return attackManager;
        }

        public Rigidbody getRigidbody()
        {
            return rbd;
        }

        public Transform getTransform()
        {
            return transform;
        }

        public IMovement getMovement()
        {
            return movement;
        }

        public void changeMovement(MovementEnum movementEnum)
        {
            // Movement states life cycles
            movement.cleanUp(); // cleaning up the current movement
            movement = movements[movementEnum]; // changing the current movement to the new one
            movement.setUp(); // setting up new movement
        }

        public Stats getStats()
        {
            return stats;
        }

        public void changeMovementDirection(IMovementDirection movementDirection)
        {
            this.movementDirection = movementDirection;
        }

        public void changeMovementDirection(CameraView cameraView)
        {
            movementDirection = setCameraDirection(cameraView);
        }

        /// <summary>
        /// Creating <b>ALL POSSIBLE</b> movements at the Start
        /// That way we don't need to create a new movement each time we change the movement state
        /// We can just use movements[MovementEnum] to get each movement
        /// We are using this array in changeMovement(MovementEnum)
        /// </summary>
        private void initMovements()
        {
            movements.Add(MovementEnum.Ground, new GroundMovement(this));
            movements.Add(MovementEnum.Midair, new MidairMovement(this));
            movements.Add(MovementEnum.Crouch, new CrouchingMovement(this));
            movements.Add(MovementEnum.Slide, new SlidingMovement(this));
            movements.Add(MovementEnum.Attack, new AttackingMovement(this));
        }

        public void dealDamage(IHurtbox hurtbox)
        {
            attackManager.dealDamage(hurtbox);
        }
    }
}