using Characters;
using General;
using UnityEngine;

namespace Animators
{
    public class AnimatorFacade : IAnimatorFacade
    {
        private readonly ICharacterAnimator _characterAnimator;
        private readonly ICharacter _character;
        private bool _unskippable;

        public AnimatorFacade(ICharacterAnimator characterAnimator, ICharacter character)
        {
            this._characterAnimator = characterAnimator;
            this._character = character;
        }


        public Animator getAnimator()
        {
            return _characterAnimator.getAnimator();
        }

        public void UpdateInputs()
        {
            SetInputs(InputManager.getHorInput(), InputManager.getVerInput(), InputManager.getMagnitude());
        }

        public void SetInputs(float horInput, float verInput, float inputMagnitude)
        {
            _characterAnimator.SetHorInput(horInput);
            _characterAnimator.SetVerInput(verInput);
            _characterAnimator.SetInputMagnitude(inputMagnitude);
        }

        public void SetGroundVelocity(float groundVelocity)
        {
            _characterAnimator.SetGroundVelocity(groundVelocity);
        }

        public void SetIsFalling(bool isFalling)
        {
            _characterAnimator.SetIsFalling(CheckIfUnskippable(isFalling));
        }

        public void SetIsAboutToLand(bool isAboutToLand)
        {
            _characterAnimator.SetIsAboutToLand(CheckIfUnskippable(isAboutToLand));
            if (isAboutToLand)
            {
                SetIsFalling(false);
            }
        }

        public void UntoggleAirAnimations()
        {
            SetIsFalling(false);
            SetIsAboutToLand(false);
        }

        public void SetJumping(bool jumping)
        {
            _unskippable = jumping;
            _characterAnimator.SetJumping(jumping);
        }

        public void SetCrouching(bool crouching)
        {
            _characterAnimator.SetCrouching(crouching);
        }

        public void SetSliding(bool sliding)
        {
            _characterAnimator.SetSliding(sliding);
        }

        public void StrongAttack(bool combo)
        {
            if (combo)
            {
                _characterAnimator.SetComboAttack();
            }

            _characterAnimator.TriggerStrongAttack();
        }

        public void FastAttack(bool combo)
        {
            if (combo)
            {
                _characterAnimator.SetComboAttack();
            }

            _characterAnimator.TriggerFastAttack();
        }

        public void ResetAttacks()
        {
            _characterAnimator.ResetFastAttack();
            _characterAnimator.ResetStrongAttack();
            _characterAnimator.ResetComboAttack();
        }

        public void SetUnskippable(bool unskippable)
        {
            this._unskippable = unskippable;
            _characterAnimator.SetUnskippable(unskippable);
        }


        private bool CheckIfUnskippable(bool stateToCheck)
        {
            return !_unskippable && stateToCheck;
        }
    }
}