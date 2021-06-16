using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class MidairMovement : AbstractMovement, IJumpable, IFallable
    {
        private bool oldAboutToLand = false;

        private int currentJumps;

        public MidairMovement(IPhysicsCharacter character) : base(character)
        {
        }

        public override void setUp()
        {
            currentJumps = stats.maxJumps;
        }

        public override void move(Vector3 direction)
        {
            // if the character is not in the air, change the movement state to ground movement
            if (!isFalling())
            {
                animatorFacade.untoggleAirAnimations();
                changeMovement(MovementEnum.Ground);
                return;
            }

            updateAnimations(direction);
            // updating velocity
            // In air we usually move slower (stats.airSpeed < stats.Speed)
            // But this should only affect X,Z axis, because Y is the gravity
            addVelocity(
                CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.airSpeed));

            calculateVelocity();
            rotate(direction);
        }

        private void calculateVelocity()
        {
            // If the character is falling too fast, clamping Y velocity to stats.maxDownVelocity
            if (rbd.velocity.y < stats.maxDownVelocity)
            {
                rbd.velocity = CommonMethods.modifyYinVector(rbd.velocity, stats.maxDownVelocity);
            }
            else // If not, then applying acceleration force down (gravity)
            {
                rbd.AddForce(Vector3.down * stats.additionalGravityForce, ForceMode.Acceleration);
            }
        }

        private void updateAnimations(Vector3 direction)
        {
            animatorFacade.updateInputs();
            animatorFacade.setIsFalling(true);
            updateLandingAnimation(direction);
        }

        private void updateLandingAnimation(Vector3 direction)
        {
            // Caching the variable, so we only invoking setIsAboutToLand when the value of oldAboutToLand has changed
            float yValue = rbd.velocity.y;
            if (yValue < 0 && CommonMethods.isAboutToLand(transform.position, direction,
                CommonMethods.normalizeValue(yValue, stats.maxDownVelocity)) != oldAboutToLand)
            {
                oldAboutToLand = !oldAboutToLand;
                animatorFacade.setIsAboutToLand(oldAboutToLand);
            }
        }


        public void jump()
        {
            if (currentJumps == 0)
            {
                return;
            }

            rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
            currentJumps--;
        }

        public override void cleanUp()
        {
            animatorFacade.untoggleAirAnimations();
        }

        public bool isFalling()
        {
            return !CommonMethods.onGround(transform.position);
        }
    }
}