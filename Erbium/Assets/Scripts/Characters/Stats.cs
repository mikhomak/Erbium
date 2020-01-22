using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float airSpeed = 5f;
        [SerializeField] private float rotationSpeed = 0.1f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float additionalGravityForce = 20f;
        [SerializeField] private float crouchSpeed = 6f;
        [SerializeField] private float health;

        
        
        public float JumpForce {
            get => jumpForce;
            set => jumpForce = value;
        }

        public float RotationSpeed {
            get => rotationSpeed;
            set => rotationSpeed = value;
        }

        public float Speed {
            get => speed;
            set => speed = value;
        }

        public float AirSpeed {
            get => airSpeed;
            set => airSpeed = value;
        }

        public float AdditionalGravityForce {
            get => additionalGravityForce;
            set => additionalGravityForce = value;
        }

        public float CrouchSpeed {
            get => crouchSpeed;
            set => crouchSpeed = value;
        }

        public float Health {
            get => health;
            set => health = value;
        }

       
    }
}