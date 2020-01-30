using General;

namespace Animators {
    public class AnimatorFacade : IAnimatorFacade {
        private readonly ICharacterAnimator characterAnimator;

        private bool unskippable;

        public AnimatorFacade(ICharacterAnimator characterAnimator) {
            this.characterAnimator = characterAnimator;
        }


        public void updateInputs() {
            setInputs(InputManager.getHorInput(), InputManager.getVerInput(), InputManager.getMagnitude());
        }

        public void setInputs(float horInput, float verInput, float inputMagnitude) {
            characterAnimator.setHorInput(horInput);
            characterAnimator.setVerInput(verInput);
            characterAnimator.setInputMagnitude(inputMagnitude);
        }

        public void setGroundVelocity(float groundVelocity) {
            characterAnimator.setGroundVelocity(groundVelocity);
        }

        public void setIsFalling(bool isFalling) {
            characterAnimator.setIsFalling(checkIfUnskippable(isFalling));
        }

        public void setIsAboutToLand(bool isAboutToLand) {
            characterAnimator.setIsAboutToLand(checkIfUnskippable(isAboutToLand));
            if (isAboutToLand) {
                setIsFalling(false);
            }
        }

        public void untoggleAirAnimations() {
            setIsFalling(false);
            setIsAboutToLand(false);
        }

        public void setJumping(bool jumping) {
            unskippable = jumping;
            characterAnimator.setJumping(jumping);
        }

        public void setCrouching(bool crouching) {
            characterAnimator.setCrouching(crouching);
        }

        public void setUnskippable(bool unskippable) {
            this.unskippable = unskippable;
            characterAnimator.setUnskippable(unskippable);
        }

        
        private bool checkIfUnskippable(bool stateToCheck) {
            return !unskippable && stateToCheck;
        }
    }
}