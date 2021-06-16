using Animators;
using UnityEngine;

namespace Characters.Movement
{
    public abstract class AbstractMovement : IMovement
    {
        protected readonly Rigidbody rbd;
        protected readonly IPhysicsCharacter character;
        protected readonly Transform transform;
        protected readonly IAnimatorFacade animatorFacade;
        protected readonly Stats stats;

        protected AbstractMovement(IPhysicsCharacter character)
        {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
            stats = character.getStats();
        }

        public abstract void SetUp();

        public abstract void CleanUp();

        public abstract void Move(Vector3 direction);

        protected void AddVelocity(Vector3 movementVector)
        {
            rbd.velocity = movementVector;
        }

        protected void Rotate(Vector3 direction)
        {
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    stats.rotationSpeed);
            }
        }


        public void ChangeMovement(MovementEnum movement)
        {
            character.ChangeMovement(movement);
        }
    }
}