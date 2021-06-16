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

        public override void setUp()
        {
        }

        public override void move(Vector3 direction)
        {
            // If the character starts falling, changing the movement state to midair
            if (isFalling())
            {
                changeMovement(MovementEnum.Midair);
                return;
            }

            // If there is no direction (aka input is 0) -> changing the state to ground movement
            if (direction == Vector3.zero)
            {
                changeMovement(MovementEnum.Ground);
                return;
            }

            var velocity =
                CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.slidingSpeed);

            rbd.velocity = velocity;
            rotate(direction);
            updateAnimParameters(velocity);
        }


        private void updateAnimParameters(Vector3 groundVelocity)
        {
            animatorFacade.updateInputs();
            animatorFacade.setGroundVelocity(CommonMethods.calculateGroundVelocity(groundVelocity));
            animatorFacade.setSliding(true);
        }

        public override void cleanUp()
        {
            animatorFacade.setSliding(false);
        }

        public bool isFalling()
        {
            return !CommonMethods.onGround(transform.position);
        }

        public void jump()
        {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
        }
    }
}