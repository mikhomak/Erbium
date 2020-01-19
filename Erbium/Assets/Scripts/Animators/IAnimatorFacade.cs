namespace Animators {
    public interface IAnimatorFacade {
        void setInputs(float horInput, float verInput, float inputMagnitude);
        void setGroundVelocity(float groundVelocity);
        void setIsFalling(bool isFalling);
        void setIsAboutToLand(bool isAboutToLand);
        void untoggleAirAnimations();
    }
}