using UnityEngine;

namespace Characters.Movement.Behaviours {
    public interface IRootMotion {
        void startRootMotion();
        void setRootMotionAdditionalPosition(Vector3 position);
        void finishRootMotion();
    }
}