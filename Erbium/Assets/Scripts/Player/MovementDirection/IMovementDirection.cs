using UnityEngine;

namespace Player.MovementDirection {
    public interface IMovementDirection {
        Vector3 getDirection();
        void setPlayerTransform(Transform transform);
    }
}