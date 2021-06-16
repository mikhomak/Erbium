using UnityEngine;

namespace Animators
{
    public interface IAnimatorFacade
    {
        Animator getAnimator();
        void UpdateInputs();
        void SetInputs(float horInput, float verInput, float inputMagnitude);
        void SetGroundVelocity(float groundVelocity);
        void SetIsFalling(bool isFalling);
        void SetIsAboutToLand(bool isAboutToLand);
        void UntoggleAirAnimations();
        void SetUnskippable(bool unskippable);
        void SetJumping(bool jumping);
        void SetCrouching(bool crouching);
        void SetSliding(bool sliding);
        void StrongAttack(bool combo);
        void FastAttack(bool combo);
        void ResetAttacks();
    }
}