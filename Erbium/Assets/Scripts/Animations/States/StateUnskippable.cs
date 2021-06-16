using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Unskippable")]
    public class StateUnskippable : AnimationStateData {
        public override void UpdateAnimData(AnimationStateBase animatorState, Animator animator) { 
        }

        public override void Enter(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).SetUnskippable(true);
        }

        public override void Exit(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).SetUnskippable(false);
        }
    }
}