using Animators;
using UnityEngine;

namespace Animations {
    public abstract class AnimationStateData : ScriptableObject {
        public float Duration;
        public abstract void update(ICharacterAnimator characterAnimator);
        public abstract void enter(ICharacterAnimator characterAnimator);
        public abstract void exit(ICharacterAnimator characterAnimator);
    }
}