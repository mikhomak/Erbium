using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : AbstractMovement, IJumpable, IFallable {

        private bool oldAboutToLand = false;

        private int currentJumps;

        public MidairMovement(IPhysicsCharacter character): base(character) {
        }

        public override void setUp() {
            currentJumps = stats.maxJumps;
        }

        public override void move(Vector3 direction) {
            if (!isFalling()) {
                animatorFacade.untoggleAirAnimations();
                changeMovement(MovementEnum.Ground);
                return;
            }

            updateAnimations(direction);
            addVelocity(
                CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.airSpeed));
            
            calculateVelocity();
            rotate(direction);
        }

        private void calculateVelocity() {
            if (rbd.velocity.y < stats.maxDownVelocity) {
                rbd.velocity = CommonMethods.modifyYinVector(rbd.velocity, stats.maxDownVelocity);
            }
            else {
                rbd.AddForce(Vector3.down * stats.additionalGravityForce, ForceMode.Acceleration);
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
                    CommonMethods.normalizeValue(yValue, stats.maxDownVelocity))) {
                oldAboutToLand = !oldAboutToLand;
                animatorFacade.setIsAboutToLand(true);
            }
        }


        public void jump() {
            if (currentJumps != 0) {
                rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
                currentJumps--;
            }
        }

        public override void cleanUp() {
            animatorFacade.untoggleAirAnimations();
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}