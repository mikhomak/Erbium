using UnityEngine;

namespace Characters.Movement {
    public interface IMovement {
        void move(Vector3 direction);
        void changeMovement(IMovement movement);
        void cleanUp();
    }
}