using UnityEngine;

namespace Characters.Movement.Behaviours
{
    public interface IRootMotion
    {
        void StartRootMotion();
        void SetRootMotionAdditionalPosition(Vector3 position);
        void FinishRootMotion();
    }
}