﻿using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Unskippable")]
    public class StateUnskippable : AnimationStateData {
        public override void update(AnimationStateBase animatorState, Animator animator) {
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).setUnskippable(true);
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
            animatorState.getAnimatorFacade(animator).setUnskippable(false);
        }
    }
}