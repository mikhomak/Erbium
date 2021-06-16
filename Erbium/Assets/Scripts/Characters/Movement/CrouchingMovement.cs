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


        public override void SetUp()
        {
            animatorFacade.SetCrouching(true);
        }

        public override void Move(Vector3 direction)
        {
            if (IsFalling())
            {
                ChangeMovement(MovementEnum.Midair);
                return;
            }


            AddVelocity(
                CommonMethods.CreateVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y, stats.crouchSpeed));
            Rotate(direction);
            UpdateAnimParameters();
        }

        private void UpdateAnimParameters()
        {
            animatorFacade.UpdateInputs();
        }

        public override void CleanUp()
        {
            animatorFacade.SetCrouching(false);
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