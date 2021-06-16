using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class MidairMovement : AbstractMovement, IJumpable, IFallable
    {
        public bool oldAboutToLand { get; private set; } = false;

        private int _currentJumps;

        public MidairMovement(IPhysicsCharacter character) : base(character)
        {
        }

        public override void SetUp()
        {
            _currentJumps = stats.maxJumps;
        }

        public override void Move(Vector3 direction)
        {
            // if the character is not in the air, change the movement state to ground movement
            if (!IsFalling())
            {
                animatorFacade.UntoggleAirAnimations();
                ChangeMovement(MovementEnum.Ground);
                return;
            }

            UpdateAnimations(direction);
            // updating velocity
            // In air we usually move slower (stats.airSpeed < stats.Speed)
            // But this should only affect X,Z axis, because Y is the gravity
            AddVelocity(
                CommonMethods.CreateVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.airSpeed));

            CalculateVelocity();
            Rotate(direction);
        }

        private void CalculateVelocity()
        {
            // If the character is falling too fast, clamping Y velocity to stats.maxDownVelocity
            if (rbd.velocity.y < stats.maxDownVelocity)
            {
                rbd.velocity = CommonMethods.ModifyYinVector(rbd.velocity, stats.maxDownVelocity);
            }
            else // If not, then applying acceleration force down (gravity)
            {
                rbd.AddForce(Vector3.down * stats.additionalGravityForce, ForceMode.Acceleration);
            }
        }

        private void UpdateAnimations(Vector3 direction)
        {
            animatorFacade.UpdateInputs();
            animatorFacade.SetIsFalling(true);
            UpdateLandingAnimation(direction);
        }

        private void UpdateLandingAnimation(Vector3 direction)
        {
            // Caching the variable, so we only invoking setIsAboutToLand when the value of oldAboutToLand has changed
            float yValue = rbd.velocity.y;
            if (yValue < 0 && CommonMethods.IsAboutToLand(transform.position, direction,
                CommonMethods.NormalizeValue(yValue, stats.maxDownVelocity)) != oldAboutToLand)
            {
                oldAboutToLand = !oldAboutToLand;
                animatorFacade.SetIsAboutToLand(oldAboutToLand);
            }
        }


        public void Jump()
        {
            if (_currentJumps == 0)
            {
                return;
            }

            rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
            _currentJumps--;
        }

        public override void CleanUp()
        {
            animatorFacade.UntoggleAirAnimations();
        }

        public bool IsFalling()
        {
            return !CommonMethods.ONGround(transform.position);
        }
    }
}