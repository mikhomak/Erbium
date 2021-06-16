using UnityEngine;

namespace Animators
{
    public class CharacterAnimator : MonoBehaviour, ICharacterAnimator
    {
        private Animator _animator;
        private static readonly int InputMagnitude = Animator.StringToHash("inputMagnitude");
        private static readonly int VerInput = Animator.StringToHash("verInput");
        private static readonly int HorInput = Animator.StringToHash("horInput");
        private static readonly int GroundVelocity = Animator.StringToHash("groundVelocity");
        private static readonly int IsFalling = Animator.StringToHash("isFalling");
        private static readonly int IsAboutToLand = Animator.StringToHash("isAboutToLand");
        private static readonly int Crouching = Animator.StringToHash("crouching");
        private static readonly int Unskippable = Animator.StringToHash("unskippable");
        private static readonly int Sliding = Animator.StringToHash("sliding");
        private static readonly int StrongAttack = Animator.StringToHash("strongAttack");
        private static readonly int ComboAttack = Animator.StringToHash("comboAttack");
        private static readonly int FastAttack = Animator.StringToHash("fastAttack");

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
        }

        public Animator getAnimator()
        {
            return _animator;
        }

        public void SetHorInput(float horInput)
        {
            _animator.SetFloat(HorInput, horInput);
        }

        public void SetVerInput(float verInput)
        {
            _animator.SetFloat(VerInput, verInput);
        }

        public void SetInputMagnitude(float inputMagnitude)
        {
            _animator.SetFloat(InputMagnitude, inputMagnitude);
        }

        public void SetGroundVelocity(float groundVelocity)
        {
            _animator.SetFloat(GroundVelocity, groundVelocity);
        }

        public void SetIsFalling(bool isFalling)
        {
            _animator.SetBool(IsFalling, isFalling);
        }

        public void SetIsAboutToLand(bool isAboutToLand)
        {
            _animator.SetBool(IsAboutToLand, isAboutToLand);
        }

        public void SetJumping(bool jumping)
        {
            if (jumping)
            {
                _animator.CrossFade("jump", 0.2f);
            }
        }

        public void SetCrouching(bool crouching)
        {
            _animator.SetBool(Crouching, crouching);
        }

        public void SetUnskippable(bool unskippable)
        {
            _animator.SetBool(Unskippable, unskippable);
        }

        public void SetSliding(bool sliding)
        {
            _animator.SetBool(Sliding, sliding);
        }

        public void TriggerStrongAttack()
        {
            _animator.SetTrigger(StrongAttack);
        }

        public void TriggerFastAttack()
        {
            _animator.SetTrigger(FastAttack);
        }

        public void SetComboAttack()
        {
            _animator.SetTrigger(ComboAttack);
        }

        public void ResetComboAttack()
        {
            _animator.ResetTrigger(ComboAttack);
        }

        public void ResetStrongAttack()
        {
            _animator.ResetTrigger(StrongAttack);
        }

        public void ResetFastAttack()
        {
            _animator.ResetTrigger(FastAttack);
        }
    }
}