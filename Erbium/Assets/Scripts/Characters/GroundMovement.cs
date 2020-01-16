using System;
using General;
using UnityEngine;

namespace Characters {
    public class GroundMovement : IMovement {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;

        public GroundMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
        }

        public void move() {
            rbd.velocity = MovementDirection.getCameraForwardDirection() * character.getStats().getSpeed();
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }
    }
}