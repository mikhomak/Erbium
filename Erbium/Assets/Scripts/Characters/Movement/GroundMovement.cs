using Animators;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class GroundMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;

        public GroundMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
            animatorFacade.untoggleAirAnimations();
            Debug.Log("now grounded");
        }

        public void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(new MidairMovement(character));
            }

            rbd.velocity = direction * character.getStats().Speed;
            rotate(direction);
            updateAnimParameters();
        }


        private void updateAnimParameters() {
            animatorFacade.setInputs(InputManager.getHorInput(), InputManager.getVerInput(),
                InputManager.getMagnitude());
            animatorFacade.setGroundVelocity(Mathf.Abs(rbd.velocity.z));
        }


        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        public void jump() {
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }

        public void changeMovement(IMovement movement) {
            character.changeMovement(movement);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform);
        }
    }
}