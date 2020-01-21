using Animators;
using UnityEditor.Animations;
using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Jump")]
    public class StateJump : AnimationStateData {
        public override void update(AnimationStateBase animatorState, Animator animator) {
            
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).setJumping(true);
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).setJumping(false);
        }
    }
}