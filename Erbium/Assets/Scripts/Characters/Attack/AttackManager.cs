using Animators;
using Characters.Damage;
using Characters.Hurtbox;
using Characters.Movement;

namespace Characters.Attack
{
    public class AttackManager : IAttackManager
    {
        private int _currentCombo;
        private bool _combo;
        private DamageInfo _currentDamageInfo;
        private readonly IAnimatorFacade _animatorFacade;
        private readonly ICharacter _character;

        public AttackManager(IAnimatorFacade animatorFacade, ICharacter character)
        {
            this._animatorFacade = animatorFacade;
            this._character = character;
        }

        public void StrongAttack()
        {
            if (!IsItPossibleToAttackWithCurrentMovement())
            {
                return;
            }

            MakeSureItsAttackingMovement();
            _animatorFacade.StrongAttack(_combo);
        }

        public void FastAttack()
        {
            if (!IsItPossibleToAttackWithCurrentMovement())
            {
                return;
            }

            MakeSureItsAttackingMovement();
            _animatorFacade.FastAttack(_combo);
        }


        public void AddCombo()
        {
            _combo = true;
            _currentCombo++;
        }


        public void ResetCombo()
        {
            _combo = false;
            _currentCombo = 0;
            _animatorFacade.ResetAttacks();
            _character.ChangeMovement(MovementEnum.Ground);
        }

        public int getCurrentCombo()
        {
            return _currentCombo;
        }

        private void MakeSureItsAttackingMovement()
        {
            if (_character.getMovement() is GroundMovement)
            {
                _character.ChangeMovement(MovementEnum.Attack);
            }
        }

        private bool IsItPossibleToAttackWithCurrentMovement()
        {
            IMovement currentMovement = _character.getMovement();
            
            return currentMovement is GroundMovement || currentMovement is AttackingMovement || 
                   currentMovement is MidairMovement {oldAboutToLand: true};
        }

        public void CreateDamageInfo(DamageInfo damageInfo)
        {
            _currentDamageInfo = damageInfo;
        }

        public void DealDamage(IHurtbox hurtbox)
        {
            hurtbox.TakeDamage(_currentDamageInfo);
        }
    }
}