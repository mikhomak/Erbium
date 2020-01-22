using System;
using Animators;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class CrouchingMovement : IMovement, IFallable, IJumpable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;

        public CrouchingMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
        }


        public void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(new MidairMovement(character));
            }

            var velocity =
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().CrouchSpeed);

            rbd.velocity = velocity;
            rotate(direction);
            updateAnimParameters();
        }


        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        private void updateAnimParameters() {
            animatorFacade.updateInputs();
            animatorFacade.setCrouching(true);
        }

        public void changeMovement(IMovement movement) {
            character.changeMovement(movement);
        }

        public void cleanUp() {
            animatorFacade.setCrouching(false);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform);
        }

        public void jump() {
            animatorFacade.setJumping(true);
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }
    }
}