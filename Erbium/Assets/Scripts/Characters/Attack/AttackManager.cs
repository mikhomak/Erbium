using Animators;

namespace Characters.Attack {
    public class AttackManager : IAttackManager {
        private int currentCombo;
        private bool canAttack = true;
        private bool attacking;
        private bool combo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character) {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void attack() {
            if (canAttack) {
                if (attacking == false && combo == false) {
                    animatorFacade.startAttacking(false);
                    attacking = true;
                    canAttack = false;
                }
                else {
                    animatorFacade.startAttacking(true);
                    canAttack = false;
                }
            }
        }

        public void addCombo() {
            combo = true;
            currentCombo++;
            attacking = true;
            canAttack = true;
        }

        public void resetCombo() {
            combo = false;
            currentCombo = 0;
            attacking = false;
            canAttack = true;
        }
    }
}