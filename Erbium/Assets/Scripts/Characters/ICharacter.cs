﻿using Animators;
using Characters.Armour;
using Characters.Attack;
using Characters.Health;
using Characters.Movement;

namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        IHealthComponent getHealthComponent();
        IAnimatorFacade getAnimatorFacade();
        IArmour getArmour();
        IAttackManager getAttackManager();
        void changeMovement(MovementEnum movementEnum);
        void die();
        Stats getStats();
    }
}