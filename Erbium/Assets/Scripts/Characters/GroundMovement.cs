using System;
using UnityEngine;

namespace Characters {
    public class GroundMovement : IMovement {
        private Rigidbody rbd;

        public GroundMovement(Rigidbody rbd) {
            this.rbd = rbd;
        }

        public void move(Vector3 direction) {
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