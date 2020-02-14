using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;
        private bool oldAboutToLand = false;

        private int currentJumps;

        public MidairMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
        }

        public void setUp() {
            currentJumps = character.getStats().MaxJumps;
        }

        public void move(Vector3 direction) {
            if (!isFalling()) {
                animatorFacade.untoggleAirAnimations();
                changeMovement(MovementEnum.Ground);
                return;
            }

            updateAnimations(direction);
            var newDirection =
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().AirSpeed);
            rbd.velocity = newDirection;
            calculateVelocity();
            rotate(direction);
        }

        private void calculateVelocity() {
            if (rbd.velocity.y < character.getStats().MaxDownVelocity) {
                rbd.velocity = CommonMethods.modifyYinVector(rbd.velocity, character.getStats().MaxDownVelocity);
            }
            else {
                rbd.AddForce(Vector3.down * character.getStats().AdditionalGravityForce, ForceMode.Acceleration);
            }
        }

        private void updateAnimations(Vector3 direction) {
            animatorFacade.updateInputs();
            animatorFacade.setIsFalling(true);
            updateLandingAnimation(direction);
        }

        private void updateLandingAnimation(Vector3 direction) {
            // Caching the variable, so we only invoking setIsAboutToLand when the value of oldAboutToLand has changed
            float yValue = rbd.velocity.y;
            if (yValue < 0 && CommonMethods.isAboutToLand(transform.position, direction,
                    CommonMethods.normalizeValue(yValue, character.getStats().MaxDownVelocity)) != oldAboutToLand) {
                oldAboutToLand = !oldAboutToLand;
                animatorFacade.setIsAboutToLand(oldAboutToLand);
            }
        }

        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        public void jump() {
            if (currentJumps != 0) {
                rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
                currentJumps--;
            }
        }

        public void changeMovement(MovementEnum movement) {
            character.changeMovement(movement);
        }

        public void cleanUp() {
            animatorFacade.untoggleAirAnimations();
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}