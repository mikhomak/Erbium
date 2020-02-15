using UnityEngine;

namespace Animators {
    public interface ICharacterAnimator {
        Animator getAnimator();
        void setHorInput(float horInput);
        void setVerInput(float verInput);
        void setInputMagnitude(float inputMagnitude);
        void setGroundVelocity(float groundVelocity);
        void setIsFalling(bool isFalling);
        void setIsAboutToLand(bool isAboutToLand);
        void setJumping(bool jumping);
        void setCrouching(bool crouching);
        void setUnskippable(bool unskippable);
        void setSliding(bool sliding);
        void setAttacking();
    }
}