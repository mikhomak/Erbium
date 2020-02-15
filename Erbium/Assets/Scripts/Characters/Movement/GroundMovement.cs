using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class GroundMovement : AbstractMovement, IJumpable, IFallable {
        public GroundMovement(IPhysicsCharacter character) : base(character) {
        }

        public override void setUp() {
        }

        public override void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(MovementEnum.Midair);
            }

            var velocity =
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().Speed);

            rbd.velocity = velocity;
            rotate(direction);
            updateAnimParameters(velocity);
        }


        private void updateAnimParameters(Vector3 groundVelocity) {
            animatorFacade.updateInputs();
            animatorFacade.setGroundVelocity(CommonMethods.calculateGroundVelocity(groundVelocity));
        }


        public void jump() {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }


        public override void cleanUp() {
            return;
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}