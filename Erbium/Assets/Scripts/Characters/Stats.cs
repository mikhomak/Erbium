using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour, IStats {
        [SerializeField] private float speed;
        [SerializeField] private float health;

        public float getSpeed() {
            return speed;
        }

        public float getHealth() {
            return health;
        }

        public void setSpeed(float newSpeed) {
            speed = speed;
        }

        public void setHealth(float newHealth) {
            health = health;
        }
    }
}