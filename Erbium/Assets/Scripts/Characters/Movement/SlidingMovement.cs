using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class SlidingMovement : AbstractMovement, IFallable, IJumpable {
        public SlidingMovement(IPhysicsCharacter character) : base(character) {
        }

        public override void setUp() {
        }

        public override void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(MovementEnum.Midair);
                return;
            }

            if (direction == Vector3.zero) {
                changeMovement(MovementEnum.Ground);
                return;
            }

            var velocity =
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().SlidingSpeed);

            rbd.velocity = velocity;
            rotate(direction);
            updateAnimParameters(velocity);
        }


        private void updateAnimParameters(Vector3 groundVelocity) {
            animatorFacade.updateInputs();
            animatorFacade.setGroundVelocity(CommonMethods.calculateGroundVelocity(groundVelocity));
            animatorFacade.setSliding(true);
        }

        public override void cleanUp() {
            animatorFacade.setSliding(false);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }

        public void jump() {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }
    }
}