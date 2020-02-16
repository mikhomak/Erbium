using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Combo Attack")]
    public class StateComboAttacking : AnimationStateData {
        public override void update(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorStateFacade(animator).makeSureTheCharacterCanComboAttack();
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorStateFacade(animator).startRangeForAttack();
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorStateFacade(animator).finishRangeForAttack();
        }
    }
}