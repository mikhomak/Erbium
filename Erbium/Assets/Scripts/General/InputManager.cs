using System;
using Characters;
using Characters.Movement;
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
                player.changeMovement(new GroundMovement(player));
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