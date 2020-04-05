using Characters.Damage;
using Characters.Hurtbox;
using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        [Header("Movement speed")] public float speed = 10f;
        public float acceleration = 30f;
        public float airSpeed = 5f;
        public float rotationSpeed = 0.1f;
        public float crouchSpeed = 6f;
        public float slidingSpeed = 15f;
        [Header("Jumping/falling")] public float jumpForce = 10f;
        public float additionalGravityForce = 20f;
        public int maxJumps = 2;
        public float maxDownVelocity = -20f;
        [Header("Armour")] public float physicArmour = 2f;
        public float magicArmour = 1f;
        public float toxicArmour = 0.5f;
        [Header("Health")] public float health = 100f;
        public float invincibilityTime = 2f;
        public float headDamageMultiplier = 2f;
        public float bodyDamageMultiplier = 1f;

        public float getArmour(DamageType damageType) {
            float result = 0.0f;
            switch (damageType) {
                case DamageType.Physical:
                    result = physicArmour;
                    break;
                case DamageType.Magical:
                    result = magicArmour;
                    break;
                case DamageType.Toxic:
                    result = toxicArmour;
                    break;
                default:
                    result = 0.0f;
                    break;
            }

            return result;
        }

        public float getBodyPartMultiplier(BodyPartHurtbox bodyPart) {
            float result = 0.0f;
            switch (bodyPart) {
                case BodyPartHurtbox.Body:
                    result = bodyDamageMultiplier;
                    break;
                case BodyPartHurtbox.Head:
                    result = headDamageMultiplier;
                    break;
                default:
                    result = 0.0f;
                    break;
            }

            return result;
        }
    }
}