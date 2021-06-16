using Characters;
using Characters.Attack;
using Characters.Movement;
using Characters.Movement.Behaviours;
using UnityEngine;

namespace Animators
{
    public class AnimatorStateFacade : MonoBehaviour, IAnimatorStateFacade
    {
        private IAttackManager attackManager;
        private Animator animator;
        private ICharacter character;

        private void Start()
        {
            character = GetComponentInParent<ICharacter>();
            attackManager = character.getAttackManager();
            animator = GetComponent<Animator>();
        }

        public void finishTimeForCombo()
        {
            makeSureAttackManagerIsNotNull();
            attackManager.resetCombo();
        }

        private void makeSureAttackManagerIsNotNull()
        {
            attackManager = attackManager ?? character.getAttackManager();
        }

        private void makeSureCharacterIsNotNull()
        {
            character = character ?? GetComponentInParent<ICharacter>();
        }

        private void OnAnimatorMove()
        {
            makeSureCharacterIsNotNull();
            var movement = character.getMovement();
            if (!animator || !(movement is AttackingMovement) || !(movement is IRootMotion)) return;
            ((IRootMotion) movement).setRootMotionAdditionalPosition(animator.deltaPosition);
        }
    }
}