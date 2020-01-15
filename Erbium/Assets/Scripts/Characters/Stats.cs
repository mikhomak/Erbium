using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        private static float speed;
        private static float health;

        public static float getSpeed() {
            return speed;
        }

        public static float getHealth() {
            return health;
        }

        public static void setSpeed(float newSpeed) {
            speed = speed;
        }

        public static void setHealth(float newHealth) {
            health = health;
        }
    }
}
