using Animators;
using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class SlidingMovement : IMovement, IFallable, IJumpable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;

        public SlidingMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
        }

        public void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(new MidairMovement(character));
                return;
            }

            if (direction == Vector3.zero) {
                changeMovement(new GroundMovement(character));
                return;
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
            animatorFacade.setSliding(true);
        }


        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }


        public void changeMovement(IMovement movement) {
            character.changeMovement(movement);
        }

        public void cleanUp() {
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