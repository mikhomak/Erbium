using UnityEngine;

namespace Characters {
    public interface IMovement {
        void move(Vector3 direction);
        void jump();
    }
}