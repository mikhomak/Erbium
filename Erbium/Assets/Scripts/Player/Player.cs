using System;
using Characters;
using UnityEngine;

namespace Player {
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Stats))]
    public class Player : MonoBehaviour, IPhysicsCharacter {
        private IMovement movement;
        [SerializeField] private Rigidbody rbd;
        [SerializeField] private Stats stats;

        private void Start() {
            rbd = GetComponent<Rigidbody>();
            stats = GetComponent<Stats>();
            movement = new GroundMovement(this);
        }

        private void FixedUpdate() {
            movement.move();
        }

        public IMovement getMovement() {
            return movement;
        }

        public void die() {
            throw new NotImplementedException();
        }

        public Stats getStats() {
            return stats;
        }

        public Rigidbody getRigidbody() {
            return rbd;
        }
    }
}