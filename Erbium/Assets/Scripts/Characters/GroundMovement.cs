using System;
using Camera;
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
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            Vector3 direction = forward * InputManager.getVerInput() + right * InputManager.getHorInput();
            rbd.velocity = direction * character.getStats().getSpeed();
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            throw new NotImplementedException();
        }
    }
}