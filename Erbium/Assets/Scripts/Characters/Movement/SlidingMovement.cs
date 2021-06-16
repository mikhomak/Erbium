using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class SlidingMovement : AbstractMovement, IFallable, IJumpable
    {
        public SlidingMovement(IPhysicsCharacter character) : base(character)
        {
        }

        public override void SetUp()
        {
        }

        public override void Move(Vector3 direction)
        {
            // If the character starts falling, changing the movement state to midair
            if (IsFalling())
            {
                ChangeMovement(MovementEnum.Midair);
                return;
            }

            // If there is no direction (aka input is 0) -> changing the state to ground movement
            if (direction == Vector3.zero)
            {
                ChangeMovement(MovementEnum.Ground);
                return;
            }

            var velocity =
                CommonMethods.CreateVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.slidingSpeed);

            rbd.velocity = velocity;
            Rotate(direction);
            UpdateAnimParameters(velocity);
        }


        private void UpdateAnimParameters(Vector3 groundVelocity)
        {
            animatorFacade.UpdateInputs();
            animatorFacade.SetGroundVelocity(CommonMethods.CalculateGroundVelocity(groundVelocity));
            animatorFacade.SetSliding(true);
        }

        public override void CleanUp()
        {
            animatorFacade.SetSliding(false);
        }

        public bool IsFalling()
        {
            return !CommonMethods.ONGround(transform.position);
        }

        public void Jump()
        {
            animatorFacade.SetJumping(true);
            rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
        }
    }
}