using System.Collections.Generic;
using Animators;
using Characters;
using UnityEngine;

namespace Animations {
    public class AnimationStateBase : StateMachineBehaviour {
        private IAnimatorFacade animatorFacade;
        [SerializeField] private List<AnimationStateData> animationStatesDatas = new List<AnimationStateData>();


        public IAnimatorFacade getAnimatorFacade(Animator animator) {
            return animatorFacade ?? (animatorFacade = animator.GetComponentInParent<ICharacter>().getAnimatorFacade());
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            enterAll(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            updateAll(animator);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            exitAll(animator);
        }

        private void updateAll(Animator animator) {
            animationStatesDatas.ForEach(state => state.update(this, animator));
        }

        private void enterAll(Animator animator) {
            animationStatesDatas.ForEach(state => state.enter(this, animator));
        }

        private void exitAll(Animator animator) {
            animationStatesDatas.ForEach(state => state.exit(this, animator));
        }
    }
}