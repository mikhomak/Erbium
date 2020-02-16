using Characters;
using Characters.Attack;
using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Combo Attack")]
    public class StateComboAttacking : AnimationStateData {

        private IAttackManager attackManager;


        private IAttackManager getAttackManager(Animator animator) {
            return attackManager ?? (attackManager = animator.GetComponentInParent<ICharacter>().getAttackManager());
        }
        
        public override void update(AnimationStateBase animatorState, Animator animator) {
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
            getAttackManager(animator).addCombo();
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
        }
    }
}