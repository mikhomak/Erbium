using System;
using Animators;
using Characters;
using Characters.Armour;
using Characters.Health;
using Characters.Movement;
using General;
using Player.MovementDirection;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Stats))]
    public class Player : MonoBehaviour, IPlayer {
        private IMovement movement;
        private IAnimatorFacade animatorFacade;
        private IMovementDirection movementDirection;
        private IHealthComponent healthComponent;
        private IArmour armour;
        [SerializeField] private Rigidbody rbd;
        [SerializeField] private Stats stats;
        [SerializeField] private CameraView cameraView;

        private void Start() {
            rbd = GetComponent<Rigidbody>();
            stats = GetComponent<Stats>();
            movementDirection = setCameraDirection(cameraView);
            animatorFacade = new AnimatorFacade(GetComponentInChildren<ICharacterAnimator>());
            movement = new GroundMovement(this);
            healthComponent = new HealthComponent(this);
            armour = new Armour(this);
        }

        private void FixedUpdate() {
            movement.move(movementDirection.getDirection(transform));
        }


        public void die() {
        }


        private IMovementDirection setCameraDirection(CameraView cameraView) {
            this.cameraView = cameraView;
            switch (cameraView) {
                case CameraView.AlwaysForward:
                    return new ThirdPersonCameraDirection();
                default:
                    return new ThirdPersonCameraDirection();
            }
        }

        public IHealthComponent getHealthComponent() {
            return healthComponent;
        }

        public IAnimatorFacade getAnimatorFacade() {
            return animatorFacade;
        }

        public IArmour getArmour() {
            return armour;
        }

        public Rigidbody getRigidbody() {
            return rbd;
        }

        public Transform getTransform() {
            return transform;
        }

        public IMovement getMovement() {
            return movement;
        }

        public void changeMovement(IMovement movement) {
            this.movement.cleanUp();
            this.movement = movement;
        }

        public Stats getStats() {
            return stats;
        }

        public void changeMovementDirection(IMovementDirection movementDirection) {
            this.movementDirection = movementDirection;
        }

        public void changeMovementDirection(CameraView cameraView) {
            movementDirection = setCameraDirection(cameraView);
        }
    }
}