using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour, IStats {
        private static float speed;
        private static float health;

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
