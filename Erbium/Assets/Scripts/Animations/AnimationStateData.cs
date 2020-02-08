using UnityEngine;

namespace Animations {
    public abstract class AnimationStateData : ScriptableObject {
        public float Duration;
        public abstract void update(AnimationStateBase animatorState, Animator animator);
        public abstract void enter(AnimationStateBase animatorState, Animator animator);
        public abstract void exit(AnimationStateBase animatorState, Animator animator);
    }
}