namespace Animators {
    public interface ICharacterAnimator {
        void setHorInput(float horInput);
        void setVerInput(float verInput);
        void setInputMagnitude(float inputMagnitude);
        void setGroundVelocity(float groundVelocity);
        void setIsFalling(bool isFalling);
    }
}