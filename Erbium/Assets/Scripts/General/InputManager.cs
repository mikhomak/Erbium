using Characters;
using Characters.Movement;
using UnityEngine;

namespace General {
    public class InputManager : MonoBehaviour {
        private ICharacter player;

        
        private void Update() {
            if (Input.GetButtonDown("Jump")) {
                IMovement playerMovement = player.getMovement();
                if (playerMovement.canJump()) {
                    (playerMovement as IJumpable)?.jump();
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