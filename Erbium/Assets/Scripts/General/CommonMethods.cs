using UnityEngine;

namespace General {
    public static class CommonMethods {
        public const float GROUND_RAT_DISTANCE = 0.3f;
        public const float LANDING_RAT_DISTANCE_MIN = 3f;
        public const float LANDING_RAT_DISTANCE = 5f;
        public const float LANDING_RAT_DISTANCE_MAX = 6f;
        public const float TRANSFORM_RAYCAST_LIFT = 0.2f;
        public const int GROUND_LAYER = 1 << 8;

        public static float calculateMagnitude(float value1, float value2) {
            return Mathf.Clamp01(new Vector2(value1, value2).magnitude);
        }

        public static bool onGround(Transform transform) {
            var position = getPositionRaycastLifted(transform);
            Debug.DrawRay(position, Vector3.down * GROUND_RAT_DISTANCE);
            return Physics.Raycast(position, Vector3.down, out _, GROUND_RAT_DISTANCE, GROUND_LAYER);
        }

        public static bool isAboutToLand(Transform transform, Vector3 direction) {
            var position = getPositionRaycastLifted(transform);

            Debug.DrawRay(position,
                Vector3.down * LANDING_RAT_DISTANCE +
                direction * LANDING_RAT_DISTANCE, Color.red);
            return Physics.Raycast(position, Vector3.down, out _, LANDING_RAT_DISTANCE, GROUND_LAYER);
        }

        public static Vector3 getPositionRaycastLifted(Transform transform) {
            var position = transform.position;
            position.y += TRANSFORM_RAYCAST_LIFT;
            return position;
        }

        public static Vector3 createVectorWithoutLoosingY(Vector3 vector, float y, float multiplier) {
            var result = new Vector3(vector.x, 0, vector.z);
            result *= multiplier;
            result.y = y;
            return result;
        }

        public static float calculateGroundVelocity(Vector3 velocity) {
            Vector3 vel = velocity;
            vel.y = 0;
            return vel.magnitude;
        }


        public static float getValueInRange(float multiplier, float min, float max) {
            return multiplier * (max - min) + max;
        }
    }
}