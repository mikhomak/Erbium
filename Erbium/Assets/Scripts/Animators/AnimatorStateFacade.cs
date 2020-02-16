using Characters;
using Characters.Attack;
using UnityEngine;

namespace Animators {
    public class AnimatorStateFacade : MonoBehaviour, IAnimatorStateFacade {
        private IAttackManager attackManager;

        private void Start() {
            attackManager = GetComponentInParent<ICharacter>().getAttackManager();
        }

        public void startRangeForAttack() {
            makeSureAttackManagerIsNotNull();
            attackManager.addCombo();
        }

        public void finishRangeForAttack() {
            makeSureAttackManagerIsNotNull();
            attackManager.resetCombo();
        }

        public void makeSureTheCharacterCanComboAttack() {
            if (!inCombo()) {
                attackManager.setCombo(true);
            }
        }

        public bool inCombo() {
            return attackManager.inCombo();
        }

        private void makeSureAttackManagerIsNotNull() {
            attackManager = attackManager ?? GetComponentInParent<ICharacter>().getAttackManager();
        }
    }
}