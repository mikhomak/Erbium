using Characters;
using Characters.Attack;
using Characters.Damage;
using UnityEngine;

namespace Animations.States {
    [CreateAssetMenu(fileName = "New Animation State", menuName = "AnimationStates/Combo Attack")]
    public class StateComboAttacking : AnimationStateData {

        private IAttackManager _attackManager;
        [SerializeField] private float damage;
        [SerializeField] private DamageType damageType;


        private IAttackManager getAttackManager(Animator animator) {
            return _attackManager ?? (_attackManager = animator.GetComponentInParent<ICharacter>().getAttackManager());
        }
        
        public override void UpdateAnimData(AnimationStateBase animatorState, Animator animator) {
        }

        public override void Enter(AnimationStateBase animatorState, Animator animator) {
            getAttackManager(animator).AddCombo();
            getAttackManager(animator).CreateDamageInfo(new DamageInfo(damage,damageType));
        }

        public override void Exit(AnimationStateBase animatorState, Animator animator) {
        }
    }
}