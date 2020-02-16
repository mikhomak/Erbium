using Animators;

namespace Characters.Attack {
    public class AttackManager: IAttackManager {

        private int currentCombo;
        private bool canAttack;
        private bool combo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character) {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void attack() {
            if (!combo) {
                animatorFacade.startAttacking();
            }
            else {
                animatorFacade.
            }
        }

        public void addCombo() {
            combo = true;
            currentCombo++;
        }

        public void resetCombo() {
            combo = false;
            currentCombo = 0;
        }
    }
}