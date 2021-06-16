using Characters;
using Characters.Attack;
using Characters.Movement;
using Characters.Movement.Behaviours;
using UnityEngine;

namespace Animators
{
    public class AnimatorStateFacade : MonoBehaviour, IAnimatorStateFacade
    {
        private IAttackManager _attackManager;
        private Animator _animator;
        private ICharacter _character;

        private void Start()
        {
            _character = GetComponentInParent<ICharacter>();
            _attackManager = _character.getAttackManager();
            _animator = GetComponent<Animator>();
        }

        public void FinishTimeForCombo()
        {
            MakeSureAttackManagerIsNotNull();
            _attackManager.ResetCombo();
        }

        private void MakeSureAttackManagerIsNotNull()
        {
            _attackManager = _attackManager ?? _character.getAttackManager();
        }

        private void MakeSureCharacterIsNotNull()
        {
            _character = _character ?? GetComponentInParent<ICharacter>();
        }

        private void OnAnimatorMove()
        {
            MakeSureCharacterIsNotNull();
            var movement = _character.getMovement();
            if (!_animator || !(movement is AttackingMovement) || !(movement is IRootMotion)) return;
            ((IRootMotion) movement).SetRootMotionAdditionalPosition(_animator.deltaPosition);
        }
    }
}