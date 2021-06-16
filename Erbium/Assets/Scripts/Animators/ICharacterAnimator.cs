using UnityEngine;

namespace Animators
{
    public interface ICharacterAnimator
    {
        Animator getAnimator();
        void SetHorInput(float horInput);
        void SetVerInput(float verInput);
        void SetInputMagnitude(float inputMagnitude);
        void SetGroundVelocity(float groundVelocity);
        void SetIsFalling(bool isFalling);
        void SetIsAboutToLand(bool isAboutToLand);
        void SetJumping(bool jumping);
        void SetCrouching(bool crouching);
        void SetUnskippable(bool unskippable);
        void SetSliding(bool sliding);
        void TriggerStrongAttack();
        void TriggerFastAttack();
        void SetComboAttack();
        void ResetComboAttack();
        void ResetStrongAttack();
        void ResetFastAttack();
    }
}