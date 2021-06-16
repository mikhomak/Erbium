using Characters.Movement.Behaviours;
using General;
using UnityEngine;

namespace Characters.Movement
{
    public class AttackingMovement : AbstractMovement, IFallable, IRootMotion
    {
        private readonly Animator _animator;
        private Vector3 _rootMotionAdditionalPosition;

        public AttackingMovement(IPhysicsCharacter character) : base(character)
        {
            _animator = character.getAnimatorFacade().getAnimator();
        }

        public override void SetUp()
        {
            StartRootMotion();
        }

        public override void Move(Vector3 direction)
        {
            if (IsFalling())
            {
                ChangeMovement(MovementEnum.Midair);
                return;
            }

            var position = rbd.position;
            rbd.MovePosition(
                CommonMethods.CreateVectorWithoutLoosingY(position + _rootMotionAdditionalPosition, position.y));

            Rotate(direction);
            UpdateAnimParameters();
        }

        private void UpdateAnimParameters()
        {
            animatorFacade.UpdateInputs();
        }

        public override void CleanUp()
        {
            FinishRootMotion();
        }

        public bool IsFalling()
        {
            return !CommonMethods.ONGround(transform.position);
        }

        public void StartRootMotion()
        {
            _animator.applyRootMotion = true;
        }


        public void SetRootMotionAdditionalPosition(Vector3 position)
        {
            _rootMotionAdditionalPosition = position;
        }

        public void FinishRootMotion()
        {
            _animator.applyRootMotion = false;
        }
    }
}