using System;
using Animators;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class GroundMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;

        public GroundMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
        }

        public void move(Vector3 direction) {
            if (isFalling()) {
                character.getAnimatorFacade().setIsFalling(true);
                return;
            }
            character.getAnimatorFacade().setIsFalling(false);
            rbd.velocity = direction * character.getStats().Speed;
            rotate(direction);
            updateAnimParameters();
        }


        private void updateAnimParameters() {
            character.getAnimatorFacade().setInputs(InputManager.getHorInput(), InputManager.getVerInput(),
                InputManager.getMagnitude());
            character.getAnimatorFacade().setGroundVelocity(Mathf.Abs(rbd.velocity.z));
        }


        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        public void jump() {
            rbd.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }

        public bool isFalling() {
            return CommonMethods.onGround(transform);
        }
    }
}