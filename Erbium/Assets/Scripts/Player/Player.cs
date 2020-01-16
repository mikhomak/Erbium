using System;
using Characters;
using UnityEngine;

namespace Player {
    public class Player : MonoBehaviour, IPhysicsCharacter {

        private IMovement movement;
        private Rigidbody rbd;

        private void Start() {
            
        }

        public IMovement getMovement() {
            return movement;
        }

        public void die() {
            throw new System.NotImplementedException();
        }

        public Rigidbody getRigidbody() {
            return rbd;
        }
    }
}