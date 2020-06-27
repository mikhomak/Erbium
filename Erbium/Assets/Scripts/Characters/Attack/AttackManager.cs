using Animators;
using Characters.Damage;
using Characters.Hurtbox;
using Characters.Movement;
using UnityEngine;

namespace Characters.Attack {
    public class AttackManager : IAttackManager {
        private int currentCombo;
        private bool combo;
        private DamageInfo currentDamageInfo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;
        private bool fast = false;
        private ComboUI comboUi;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character, ComboUI comboUi) {
            this.animatorFacade = animatorFacade;
            this.character = character;
            this.comboUi = comboUi;
        }

        public void strongAttack() {
            if (!isItPossibleToAttackWithCurrentMovement()) {
                return;
            }

            makeSureItsAttackingMovement();
            animatorFacade.strongAttack(combo);

            fast = false;
        }

        public void fastAttack() {
            if (!isItPossibleToAttackWithCurrentMovement()) {
                return;
            }

            makeSureItsAttackingMovement();
            animatorFacade.fastAttack(combo);
            fast = true;

        }


        public void addCombo() {
            Debug.Log("ayo");
            combo = true;
            currentCombo++;
            comboUi.addCombo(fast);
        }


        public void resetCombo() {
            combo = false;
            currentCombo = 0;
            animatorFacade.resetAttacks();
            character.changeMovement(MovementEnum.Ground);
        }

        public int getCurrentCombo() {
            return currentCombo;
        }

        private void makeSureItsAttackingMovement() {
            if (character.getMovement() is GroundMovement) {
                character.changeMovement(MovementEnum.Attack);
            }
        }

        private bool isItPossibleToAttackWithCurrentMovement() {
            return character.getMovement() is GroundMovement || character.getMovement() is AttackingMovement;
        }

        public void createDamageInfo(DamageInfo damageInfo) {
            currentDamageInfo = damageInfo;
        }

        public void dealDamage(IHurtbox hurtbox) {
            hurtbox.takeDamage(currentDamageInfo);
        }
    }
}