using Animators;
using Characters.Damage;
using Characters.Hurtbox;
using Characters.Movement;

namespace Characters.Attack
{
    public class AttackManager : IAttackManager
    {
        private int currentCombo;
        private bool combo;
        private DamageInfo currentDamageInfo;
        private readonly IAnimatorFacade animatorFacade;
        private readonly ICharacter character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character)
        {
            this.animatorFacade = animatorFacade;
            this.character = character;
        }

        public void strongAttack()
        {
            if (!isItPossibleToAttackWithCurrentMovement())
            {
                return;
            }

            makeSureItsAttackingMovement();
            animatorFacade.strongAttack(combo);
        }

        public void fastAttack()
        {
            if (!isItPossibleToAttackWithCurrentMovement())
            {
                return;
            }

            makeSureItsAttackingMovement();
            animatorFacade.fastAttack(combo);
        }


        public void addCombo()
        {
            combo = true;
            currentCombo++;
        }


        public void resetCombo()
        {
            combo = false;
            currentCombo = 0;
            animatorFacade.resetAttacks();
            character.changeMovement(MovementEnum.Ground);
        }

        public int getCurrentCombo()
        {
            return currentCombo;
        }

        private void makeSureItsAttackingMovement()
        {
            if (character.getMovement() is GroundMovement)
            {
                character.changeMovement(MovementEnum.Attack);
            }
        }

        private bool isItPossibleToAttackWithCurrentMovement()
        {
            return character.getMovement() is GroundMovement || character.getMovement() is AttackingMovement;
        }

        public void createDamageInfo(DamageInfo damageInfo)
        {
            currentDamageInfo = damageInfo;
        }

        public void dealDamage(IHurtbox hurtbox)
        {
            hurtbox.takeDamage(currentDamageInfo);
        }
    }
}