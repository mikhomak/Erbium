using System;
using Camera;
using UnityEngine;

namespace Characters {
    public class GroundMovement : IMovement {
        private Rigidbody rbd;
        private IPhysicsCharacter character;

        public GroundMovement(IPhysicsCharacter character) {
            this.character = character;
            this.rbd = character.getRigidbody();
        }

        public void move(Vector3 direction) {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }
    }
}