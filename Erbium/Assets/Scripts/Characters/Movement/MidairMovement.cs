using System;
using Animators;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class MidairMovement : IMovement, IJumpable, IFallable {
        private readonly Rigidbody rbd;
        private readonly IPhysicsCharacter character;
        private readonly Transform transform;
        private readonly IAnimatorFacade animatorFacade;

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
            }

            animatorFacade.setIsFalling(true);
            animatorFacade.setIsAboutToLand(CommonMethods.isAboutToLand(transform));   // TODO cache the old variable

            rbd.velocity = direction * character.getStats().AirSpeed;
            rbd.AddForce(Vector3.down * 5f);
        }

        public void jump() {
            throw new NotImplementedException();
        }

        public void changeMovement(IMovement movement) {
            character.changeMovement(movement);
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform);
        }
    }
}