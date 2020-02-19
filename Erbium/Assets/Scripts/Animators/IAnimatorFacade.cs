using UnityEngine;

namespace Animators {
    public interface IAnimatorFacade {
        Animator getAnimator();
        void updateInputs();
        void setInputs(float horInput, float verInput, float inputMagnitude);
        void setGroundVelocity(float groundVelocity);
        void setIsFalling(bool isFalling);
        void setIsAboutToLand(bool isAboutToLand);
        void untoggleAirAnimations();
        void setUnskippable(bool unskippable);
        void setJumping(bool jumping);
        void setCrouching(bool crouching);
        void setSliding(bool sliding);
        void startAttacking(bool fast, bool combo);
        void resetAttacks();
    }
}