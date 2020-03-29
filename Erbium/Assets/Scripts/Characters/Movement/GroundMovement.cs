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
                return;
            }

            var velocity = accelerateAndMove(direction);

            rotate(direction);
            updateAnimParameters(velocity);
        }

        private Vector3 accelerateAndMove(Vector3 direction) {
            var velocity =
                CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y,
                    stats.speed);
            if (rbd.velocity.magnitude < velocity.magnitude) {
                var acceleration = CommonMethods.createVectorWithoutLoosingYWithMultiplier(direction, rbd.velocity.y,
                    stats.acceleration);
                rbd.AddForce(acceleration);
            }
            else {
                rbd.velocity = velocity;
            }

            return velocity;
        }


        private void updateAnimParameters(Vector3 groundVelocity) {
            animatorFacade.updateInputs();
            animatorFacade.setGroundVelocity(CommonMethods.calculateGroundVelocity(groundVelocity));
        }


        public void jump() {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * stats.jumpForce, ForceMode.Impulse);
        }


        public override void cleanUp() {
            return;
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}