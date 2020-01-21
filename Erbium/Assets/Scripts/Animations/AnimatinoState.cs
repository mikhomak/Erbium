using System.Collections.Generic;
using Animators;
using UnityEngine;

namespace Animations {
    public class AnimationState : StateMachineBehaviour {
        private ICharacterAnimator characterAnimator;
        [SerializeField] private List<AnimationStateData> animationStatesDatas = new List<AnimationStateData>();


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            enterAll();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            updateAll();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            exitAll();
        }

        public void updateAll() {
            animationStatesDatas.ForEach(state => state.update(characterAnimator));
        }

        public void enterAll() {
            animationStatesDatas.ForEach(state => state.enter(characterAnimator));
        }

        public void exitAll() {
            animationStatesDatas.ForEach(state => state.exit(characterAnimator));
        }
    }
}