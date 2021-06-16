using Characters.Movement;
using Characters.Movement.Behaviours;
using Player;
using UnityEngine;

namespace General
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] public GameObject playerGameObject;
        private static IPlayer _player;


        private void Start()
        {
            _player = playerGameObject.GetComponent<IPlayer>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                (_player.getMovement() as IJumpable)?.Jump();
            }

            if (Input.GetButton($"Crouch"))
            {
                if (_player.getMovement() is GroundMovement)
                {
                    _player.ChangeMovement(MovementEnum.Crouch);
                }
            }

            if (Input.GetButtonUp($"Crouch"))
            {
                if (_player.getMovement() is CrouchingMovement)
                {
                    _player.ChangeMovement(MovementEnum.Ground);
                }
            }

            if (Input.GetButton($"Slide"))
            {
                if (_player.getMovement() is GroundMovement)
                {
                    _player.ChangeMovement(MovementEnum.Slide);
                }
            }


            if (Input.GetButtonUp($"Slide"))
            {
                if (_player.getMovement() is SlidingMovement)
                {
                    _player.ChangeMovement(MovementEnum.Ground);
                }
            }

            if (Input.GetButtonDown($"Fire1"))
            {
                if (_player.getMovement() is GroundMovement || _player.getMovement() is AttackingMovement)
                {
                    _player.getAttackManager().StrongAttack();
                }
            }

            if (Input.GetButtonDown($"Fire2"))
            {
                if (_player.getMovement() is GroundMovement || _player.getMovement() is AttackingMovement)
                {
                    _player.getAttackManager().FastAttack();
                }
            }
        }

        public static Vector2 getAxisVector()
        {
            return new Vector2(getHorInput(), getVerInput());
        }

        public static float getHorInput()
        {
            return Input.GetAxis("Horizontal");
        }

        public static float getVerInput()
        {
            return Input.GetAxis("Vertical");
        }

        public static float getMagnitude()
        {
            return CommonMethods.CalculateMagnitude(getHorInput(), getVerInput());
        }
    }
}