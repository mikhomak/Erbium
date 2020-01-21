using General;

namespace Animators {
    public class AnimatorFacade : IAnimatorFacade {
        private readonly ICharacterAnimator characterAnimator;

        private bool jumping;

        public AnimatorFacade(ICharacterAnimator characterAnimator) {
            this.characterAnimator = characterAnimator;
        }


        public void updateInputs() {
            setInputs(InputManager.getHorInput(), InputManager.getVerInput(), InputManager.getVerInput());
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
            characterAnimator.setIsFalling(checkIfJumping(isFalling));
        }

        public void setIsAboutToLand(bool isAboutToLand) {
            characterAnimator.setIsAboutToLand(checkIfJumping(isAboutToLand));
            if (isAboutToLand) {
                setIsFalling(false);
            }
        }

        public void untoggleAirAnimations() {
            setIsFalling(false);
            setIsAboutToLand(false);
        }

        public void setJumping(bool jumping) {
            this.jumping = jumping;
            characterAnimator.setJumping(jumping);
        }

        private bool checkIfJumping(bool stateToCheck) {
            return !jumping && stateToCheck;
        }
    }
}