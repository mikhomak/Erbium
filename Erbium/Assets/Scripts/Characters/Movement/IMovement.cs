using UnityEngine;

namespace Characters.Movement {
    public interface IMovement {
        void move(Vector3 direction);
        bool canJump();
        void changeMovement(IMovement movement);
    }
}