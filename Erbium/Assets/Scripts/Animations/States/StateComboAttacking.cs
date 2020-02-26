using Characters;
using Characters.Attack;
using Characters.Damage;
using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Combo Attack")]
    public class StateComboAttacking : AnimationStateData {

        private IAttackManager attackManager;
        [SerializeField] private float damage;
        [SerializeField] private DamageType damageType;


        private IAttackManager getAttackManager(Animator animator) {
            return attackManager ?? (attackManager = animator.GetComponentInParent<ICharacter>().getAttackManager());
        }
        
        public override void update(AnimationStateBase animatorState, Animator animator) {
        }

        public override void enter(AnimationStateBase animatorState, Animator animator) {
            getAttackManager(animator).addCombo();
            getAttackManager(animator).createDamageInfo(new DamageInfo(damage,damageType));
        }

        public override void exit(AnimationStateBase animatorState, Animator animator) {
        }
    }
}