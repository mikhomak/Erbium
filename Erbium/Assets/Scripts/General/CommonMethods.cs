using UnityEngine;

namespace General {
    public static class CommonMethods {
        public const float GROUND_RAT_DISTANCE = 0.3f;
        public const float LANDING_RAT_DISTANCE_MIN = 1.5f;
        public const float LANDING_RAT_DISTANCE_MAX = 2.5f;
        public const float TRANSFORM_RAYCAST_LIFT = 0.2f;
        public const float TRANSFORM_RAYCAST_LIFT_LANDING = TRANSFORM_RAYCAST_LIFT * 2;
        public const int GROUND_LAYER = 1 << 8;

        public static float calculateMagnitude(float value1, float value2) {
            return Mathf.Clamp01(new Vector2(value1, value2).magnitude);
        }

        public static bool onGround(Vector3 position) {
            var origin = getPositionRaycastLifted(position);
            Debug.DrawRay(origin, Vector3.down * GROUND_RAT_DISTANCE);
            return Physics.Raycast(origin, Vector3.down, out _, GROUND_RAT_DISTANCE, GROUND_LAYER);
        }

        public static bool isAboutToLand(Vector3 position, Vector3 direction, float normalizedValue) {
            var origin = getPositionRaycastLiftedForLanding(position);
            position.y += 0.2f;
            var length = getValueInRange(normalizedValue, LANDING_RAT_DISTANCE_MIN, LANDING_RAT_DISTANCE_MAX);
            Debug.DrawRay(origin,
                Vector3.down * length +
                direction * length, Color.red);

            return Physics.Raycast(origin, Vector3.down * length + direction.normalized * length, out _, length,
                GROUND_LAYER);
        }

        public static Vector3 getPositionRaycastLifted(Vector3 position) {
            var res = position;
            res.y += TRANSFORM_RAYCAST_LIFT;
            return res;
        }

        public static Vector3 getPositionRaycastLiftedForLanding(Vector3 position) {
            var res = position;
            res.y += TRANSFORM_RAYCAST_LIFT_LANDING;
            return res;
        }

        public static Vector3 createVectorWithoutLoosingYWithMultiplier(Vector3 vector, float y, float multiplier) {
            var result = new Vector3(vector.x, 0, vector.z);
            result *= multiplier;
            result.y = y;
            return result;
        }

        public static Vector3 createVectorWithoutLoosingY(Vector3 vector, float y) {
            return new Vector3(vector.x, y, vector.z);
        }

        public static float calculateGroundVelocity(Vector3 velocity) {
            Vector3 vel = velocity;
            vel.y = 0;
            return vel.magnitude;
        }


        public static Vector3 modifyYinVector(Vector3 vector, float y) {
            var res = vector;
            res.y = y;
            return res;
        }


        public static Vector3 createVectorWith0InY(Vector3 vector3) {
            return new Vector3(vector3.x, 0, vector3.z);
        }

        public static float getValueInRange(float multiplier, float min, float max) {
            return multiplier * (max - min) + max;
        }

        public static float normalizeValue(float value, float max) {
            return Mathf.Abs(value / max);
        }
    }
}