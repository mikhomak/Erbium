using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class AttackingMovement : AbstractMovement, IFallable, IRootMotion
    {
        private readonly Animator animator;
        private Vector3 rootMotionAdditionalPosition;

        public AttackingMovement(IPhysicsCharacter character) : base(character)
        {
            animator = character.getAnimatorFacade().getAnimator();
        }

        public override void setUp()
        {
            startRootMotion();
        }

        public override void move(Vector3 direction)
        {
            if (isFalling())
            {
                changeMovement(MovementEnum.Midair);
                return;
            }

            var position = rbd.position;
            rbd.MovePosition(
                CommonMethods.createVectorWithoutLoosingY(position + rootMotionAdditionalPosition, position.y));

            rotate(direction);
            updateAnimParameters();
        }

        private void updateAnimParameters()
        {
            animatorFacade.updateInputs();
        }

        public override void cleanUp()
        {
            finishRootMotion();
        }

        public bool isFalling()
        {
            return !CommonMethods.onGround(transform.position);
        }

        public void startRootMotion()
        {
            animator.applyRootMotion = true;
        }


        public void setRootMotionAdditionalPosition(Vector3 position)
        {
            rootMotionAdditionalPosition = position;
        }

        public void finishRootMotion()
        {
            animator.applyRootMotion = false;
        }
    }
}