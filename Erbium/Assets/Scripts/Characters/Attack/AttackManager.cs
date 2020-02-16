using Animators;
using Characters.Movement;
using UnityEngine;

namespace Characters.Attack {
    public class AttackManager : IAttackManager {
        private int currentCombo;
        private bool canAttack = true; // ?????
        private bool combo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character) {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void attack() {
            if (canAttack) {
                if (character.getMovement() is AttackingMovement == false) {
                    character.changeMovement(MovementEnum.Attack);
                }
                if (combo == false) {
                    animatorFacade.startAttacking(false);
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
            canAttack = true;
        }

        public void resetCombo() {
            combo = false;
            currentCombo = 0;
            canAttack = true;
            animatorFacade.resetAttacks();
            character.changeMovement(MovementEnum.Ground);
        }

    }
}