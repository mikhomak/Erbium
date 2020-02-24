using Animators;
using UnityEngine;

namespace Characters.Movement {
    public abstract class AbstractMovement :IMovement {
        
        protected readonly Rigidbody rbd;
        protected readonly IPhysicsCharacter character;
        protected readonly Transform transform;
        protected readonly IAnimatorFacade animatorFacade;

        protected AbstractMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
        }

        public abstract void setUp();

        public abstract void move(Vector3 direction);

        protected virtual void addVelocity(Vector3 movementVector) {
            rbd.velocity = movementVector;
        }
        
        protected virtual void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        
        public void changeMovement(MovementEnum movement) {
            character.changeMovement(movement);
        }

        public abstract void cleanUp();
    }
}