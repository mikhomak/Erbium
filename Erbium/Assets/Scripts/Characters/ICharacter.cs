using Animators;
using Characters.Armour;
using Characters.Health;
using Characters.Movement;
using UnityEngine;

namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        IHealthComponent getHealthComponent();
        IAnimatorFacade getAnimatorFacade();
        IArmour getArmour();
        void changeMovement(IMovement movement);
        void die();
        Stats getStats();
    }
}