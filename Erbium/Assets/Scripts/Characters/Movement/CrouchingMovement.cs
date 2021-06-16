using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class CrouchingMovement : AbstractMovement, IFallable, IJumpable
    {
        public CrouchingMovement(IPhysicsCharacter character) : base(character)
        {
        }


        public override void setUp()
        {
            animatorFacade.setCrouching(true);
        }

        public override void move(Vector3 direction)
        {
            if (isFalling())
            {
                changeMovement(MovementEnum.Midair);
                return;
            }


            addVelocity(
                CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.crouchSpeed));
            rotate(direction);
            updateAnimParameters();
        }

        private void updateAnimParameters()
        {
            animatorFacade.updateInputs();
        }

        public override void cleanUp()
        {
            animatorFacade.setCrouching(false);
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