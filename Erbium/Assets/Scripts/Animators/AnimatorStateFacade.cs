using Characters;
using UnityEngine;

namespace Animators {
    public class AnimatorStateFacade : MonoBehaviour, IAnimatorStateFacade {
        private ICharacter character;

        private void Start() {
            character = GetComponentInParent<ICharacter>();
        }

        public void startRangeForAttack() {
            character.getStats().CanComboAttack = true;
        }

        public void finishRangeForAttack() {
            character.getStats().CanComboAttack = false;
        }
    }
}