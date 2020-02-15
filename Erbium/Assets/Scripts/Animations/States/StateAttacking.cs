using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Attacking")]
    public class StateAttacking : AnimationStateData {
        public override void update(AnimationStateBase animatorState, Animator animator) {
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorStateFacade(animator).finishRangeForAttack();
        }
    }
}