using Characters.Movement;
using Characters.Movement.Behaviours;
using Player;
using UnityEngine;

namespace General {
    public class InputManager : MonoBehaviour {
        [SerializeField] public GameObject playerGameObject;
        private IPlayer player;


        private void Start() {
            player = playerGameObject.GetComponent<IPlayer>();
        }

        private void Update() {
            if (Input.GetButtonDown("Jump")) {
                (player.getMovement() as IJumpable)?.jump();
            }

            if (Input.GetButton($"Crouch")) {
                if (player.getMovement() is GroundMovement) {
                    player.changeMovement(new CrouchingMovement(player));
                }
            }

            if (Input.GetButtonUp($"Crouch")) {
                if (player.getMovement() is CrouchingMovement) {
                    player.changeMovement(new GroundMovement(player));
                }
            }

            if (Input.GetButton($"Slide")) {
                if (player.getMovement() is GroundMovement) {
                    player.changeMovement(new SlidingMovement(player));
                }
            }


            if (Input.GetButtonUp($"Slide")) {
                if (player.getMovement() is SlidingMovement) {
                    player.changeMovement(new GroundMovement(player));
                }
            }
        }


        public static Vector2 getAxisVector() {
            return new Vector2(getHorInput(), getVerInput());
        }

        public static float getHorInput() {
            return Input.GetAxis("Horizontal");
        }

        public static float getVerInput() {
            return Input.GetAxis("Vertical");
        }

        public static float getMagnitude() {
            return CommonMethods.calculateMagnitude(getHorInput(), getVerInput());
        }
    }
}