namespace Animators {
    public class AnimatorFacade : IAnimatorFacade {
        private readonly ICharacterAnimator characterAnimator;

        public AnimatorFacade(ICharacterAnimator characterAnimator) {
            this.characterAnimator = characterAnimator;
        }


        public void setInputs(float horInput, float verInput, float inputMagnitude) {
            characterAnimator.setHorInput(horInput);
            characterAnimator.setVerInput(verInput);
            characterAnimator.setInputMagnitude(inputMagnitude);
        }
    }
}