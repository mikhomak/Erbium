using Animators;
using Characters.Health;
using Characters.Movement;
using UnityEngine;

namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        IHealthComponent getHealthComponent();
        IAnimatorFacade getAnimatorFacade();
        void changeMovement(IMovement movement);
        void die();
        Stats getStats();
    }
}