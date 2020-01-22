using Animators;
using Characters.Movement;
using UnityEngine;

namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        IAnimatorFacade getAnimatorFacade();
        void changeMovement(IMovement movement);
        void die();
        Stats getStats();
    }
}