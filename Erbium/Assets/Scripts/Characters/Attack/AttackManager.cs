using Animators;
using Characters.Movement;

namespace Characters.Attack {
    public class AttackManager : IAttackManager {
        private int currentCombo;
        private bool combo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character) {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void attack() {
            makeSureItsAttackingMovement();
            animatorFacade.startAttacking(combo);
        }

        public void fastAttack() {
            makeSureItsAttackingMovement();
            animatorFacade.fastAttack(combo);
        }


        public void addCombo() {
            combo = true;
            currentCombo++;
        }


        public void resetCombo() {
            combo = false;
            currentCombo = 0;
            animatorFacade.resetAttacks();
            character.changeMovement(MovementEnum.Ground);
        }

        private void makeSureItsAttackingMovement() {
            if (character.getMovement() is AttackingMovement == false) {
                character.changeMovement(MovementEnum.Attack);
            }
        }
    }
}