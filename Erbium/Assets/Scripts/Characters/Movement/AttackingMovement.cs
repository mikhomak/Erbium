using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class AttackingMovement: AbstractMovement, IFallable {
        public AttackingMovement(IPhysicsCharacter character) : base(character) {
        }

        public override void setUp() {
            rbd.AddForce(rbd.velocity.normalized, ForceMode.Impulse);
        }

        public override void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(MovementEnum.Midair);
                return;
            }


            rbd.AddForce(
                CommonMethods.createVectorWithoutLoosingY(direction, rbd.velocity.y, character.getStats().MovementSpeedAttacking));
            rotate(direction);
            updateAnimParameters();
        }

        private void updateAnimParameters() {
            animatorFacade.updateInputs();
        }

        public override void cleanUp() {
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}