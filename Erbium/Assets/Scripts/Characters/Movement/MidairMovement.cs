using System;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : IMovement, IJumpable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        public void move(Vector3 direction) {
            throw new NotImplementedException();
        }

        public bool canJump() {
            throw new NotImplementedException();
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }
    }
}
