using System.Collections.Generic;
using Animators;
using Characters;
using UnityEngine;

namespace Animations
{
    public class AnimationStateBase : StateMachineBehaviour
    {
        private IAnimatorFacade _animatorFacade;
        [SerializeField] private List<AnimationStateData> animationStatesDatas = new List<AnimationStateData>();


        public IAnimatorFacade getAnimatorFacade(Animator animator)
        {
            return _animatorFacade ?? (_animatorFacade = animator.GetComponentInParent<ICharacter>().getAnimatorFacade());
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            EnterAll(animator);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            UpdateAll(animator);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            ExitAll(animator);
        }

        private void UpdateAll(Animator animator)
        {
            animationStatesDatas.ForEach(state => state.UpdateAnimData(this, animator));
        }

        private void EnterAll(Animator animator)
        {
            animationStatesDatas.ForEach(state => state.Enter(this, animator));
        }

        private void ExitAll(Animator animator)
        {
            animationStatesDatas.ForEach(state => state.Exit(this, animator));
        }
    }
}