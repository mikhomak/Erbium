using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float airSpeed = 5f;
        [SerializeField] private float rotationSpeed = 0.1f;
        [SerializeField] private float jumpForce = 10f;
        [SerializeField] private float additionalGravityForce = 20f;
        [SerializeField] private float crouchSpeed = 6f;
        [SerializeField] private float slidingSpeed = 15f;
        [SerializeField] private int maxJumps = 2;
        [SerializeField] private float maxDownVelocity = -20f;
        [SerializeField] private float physicArmour = 2f;
        [SerializeField] private float magicArmour = 1f;
        [SerializeField] private float toxicArmour = 0.5f;
        [SerializeField] private float health = 100f;
        [SerializeField] private float invincibilityTime = 2f;
        [SerializeField] private float headDamageMultiplier = 2f;
        [SerializeField] private float bodyDamageMultiplier = 1f;
        [SerializeField] private bool canComboAttack = false;

        
        
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

        public float SlidingSpeed {
            get => slidingSpeed;
            set => slidingSpeed = value;
        }

        public int MaxJumps {
            get => maxJumps;
            set => maxJumps = value;
        }

        public float MaxDownVelocity {
            get => maxDownVelocity;
            set => maxDownVelocity = value;
        }

        public float Health {
            get => health;
            set => health = value;
        }

        public float InvincibilityTime {
            get => invincibilityTime;
            set => invincibilityTime = value;
        }

        public float PhysicArmour {
            get => physicArmour;
            set => physicArmour = value;
        }

        public float MagicArmour {
            get => magicArmour;
            set => magicArmour = value;
        }

        public float ToxicArmour {
            get => toxicArmour;
            set => toxicArmour = value;
        }

        public float HeadDamageMultiplier {
            get => headDamageMultiplier;
            set => headDamageMultiplier = value;
        }

        public float BodyDamageMultiplier {
            get => bodyDamageMultiplier;
            set => bodyDamageMultiplier = value;
        }

        public bool CanComboAttack {
            get => canComboAttack;
            set => canComboAttack = value;
        }
    }
}