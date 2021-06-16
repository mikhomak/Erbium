using UnityEngine;
using UnityEngine.Serialization;

namespace Animations
{
    public abstract class AnimationStateData : ScriptableObject
    {
        [FormerlySerializedAs("Duration")] public float duration;
        public abstract void update(AnimationStateBase animatorState, Animator animator);
        public abstract void enter(AnimationStateBase animatorState, Animator animator);
        public abstract void exit(AnimationStateBase animatorState, Animator animator);
    }
}