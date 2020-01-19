using System;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;

        public MidairMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
        }

        public void move(Vector3 direction) {
            if (!isFalling()) {
                changeMovement(new GroundMovement(character));
            }
            rbd.velocity = direction * character.getStats().AirSpeed;
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform);
        }
    }
}
