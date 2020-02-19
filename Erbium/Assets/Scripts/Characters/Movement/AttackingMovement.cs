using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement {
    public class AttackingMovement: AbstractMovement, IFallable {
        private readonly Animator animator;
        
        public AttackingMovement(IPhysicsCharacter character) : base(character) {
            animator = character.getAnimatorFacade().getAnimator();
        }

        public override void setUp() {
            animator.applyRootMotion = true;
        }

        public override void move(Vector3 direction) {
            if (isFalling()) {
                changeMovement(MovementEnum.Midair);
                return;
            }


            
            rotate(direction);
            updateAnimParameters();
        }

        private void updateAnimParameters() {
            animatorFacade.updateInputs();
        }

        public override void cleanUp() {
            animator.applyRootMotion = false;
        }

        public bool isFalling() {
            return !CommonMethods.onGround(transform.position);
        }
    }
}