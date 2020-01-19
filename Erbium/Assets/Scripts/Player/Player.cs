using System;
using Animators;
using Characters;
using Characters.Movement;
using General;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Stats))]
    public class Player : MonoBehaviour, IPhysicsCharacter {
        private IMovement movement;
        private IAnimatorFacade animatorFacade;
        [SerializeField] private Rigidbody rbd;
        [SerializeField] private Stats stats;
        [SerializeField] private CameraView cameraView;

        private void Start() {
            rbd = GetComponent<Rigidbody>();
            stats = GetComponent<Stats>();
            animatorFacade = new AnimatorFacade(GetComponentInChildren<ICharacterAnimator>());
            movement = new GroundMovement(this);
        }

        private void FixedUpdate() {
            movement.move(findDirection());
        }


        public void die() {
            throw new NotImplementedException();
        }


        private Vector3 findDirection() {
            switch (cameraView) {
                case CameraView.AlwaysForward:
                    return MovementDirection.getCameraForwardDirection();
                    break;
                default:
                    return MovementDirection.getCameraForwardDirection();
                    break;
            }
        }

        public IAnimatorFacade getAnimatorFacade() {
            return animatorFacade;
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
            this.movement = movement;
        }


        public Stats getStats() {
            return stats;
        }
    }
}