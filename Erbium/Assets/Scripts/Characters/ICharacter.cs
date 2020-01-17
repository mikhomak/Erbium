using Animators;

namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        IAnimatorFacade getAnimatorFacade();
        void die();
        Stats getStats();
    }
}