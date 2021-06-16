using UnityEngine;
using UnityEngine.Serialization;

namespace Animations
{
    public abstract class AnimationStateData : ScriptableObject
    {
        [FormerlySerializedAs("Duration")] public float duration;
        public abstract void UpdateAnimData(AnimationStateBase animatorState, Animator animator);
        public abstract void Enter(AnimationStateBase animatorState, Animator animator);
        public abstract void Exit(AnimationStateBase animatorState, Animator animator);
    }
}