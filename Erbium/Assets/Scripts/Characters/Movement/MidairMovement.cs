﻿using System;
using Animators;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;
        private bool oldAboutToLand = false;

        public MidairMovement(IPhysicsCharacter character) {
            this.character = character;
            rbd = character.getRigidbody();
            transform = character.getTransform();
            animatorFacade = character.getAnimatorFacade();
        }

        public void move(Vector3 direction) {
            if (!isFalling()) {
                animatorFacade.untoggleAirAnimations();
                changeMovement(new GroundMovement(character));
                return;
            }

            animatorFacade.setIsFalling(true);
            // Caching the variable, so we only invoking setIsAboutToLand when the value of oldAboutToLand has changed
            if (rbd.velocity.y < 0 && CommonMethods.isAboutToLand(transform) != oldAboutToLand) {
                oldAboutToLand = !oldAboutToLand;
                animatorFacade.setIsAboutToLand(oldAboutToLand);
            }


            var newDirection = new Vector3( direction.x * character.getStats().AirSpeed, rbd.velocity.y, direction.z * character.getStats().AirSpeed);
            rbd.velocity = newDirection;
            rbd.AddForce(Vector3.down * character.getStats().AdditionalGravityForce, ForceMode.Acceleration);
            rotate(direction);
        }

        private void rotate(Vector3 direction) {
            if (direction != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    character.getStats().RotationSpeed);
            }
        }

        public void jump() {
            rbd.AddForce(Vector3.up * character.getStats().JumpForce, ForceMode.Impulse);
        }

        public void changeMovement(IMovement movement) {
            character.changeMovement(movement);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform);
        }
    }
}