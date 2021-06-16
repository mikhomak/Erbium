using UnityEngine;

namespace General
{
    public static class CommonMethods
    {
        private const float GroundRatDistance = 0.3f;
        public const float LandingRatDistanceMIN = 1.5f;
        private const float LandingRatDistanceMAX = 2f;
        private const float TransformRaycastLift = 0.2f;
        private const float TransformRaycastLiftLanding = TransformRaycastLift * 2;
        private const int GroundLayer = 1 << 8;

        public static float CalculateMagnitude(float value1, float value2)
        {
            return Mathf.Clamp01(new Vector2(value1, value2).magnitude);
        }

        public static bool ONGround(Vector3 position)
        {
            var origin = getPositionRaycastLifted(position);
            Debug.DrawRay(origin, Vector3.down * GroundRatDistance);
            return Physics.Raycast(origin, Vector3.down, out _, GroundRatDistance, GroundLayer);
        }

        public static bool IsAboutToLand(Vector3 position, Vector3 direction, float normalizedValue)
        {
            var origin = getPositionRaycastLiftedForLanding(position);
            position.y += 0.2f;
            var length = getValueInRange(normalizedValue, LandingRatDistanceMIN, LandingRatDistanceMAX);
            Debug.DrawRay(origin,
                Vector3.down * length +
                direction * length, Color.red);

            return Physics.Raycast(origin, Vector3.down * length + direction.normalized * length, out _, length,
                GroundLayer);
        }

        public static Vector3 getPositionRaycastLifted(Vector3 position)
        {
            var res = position;
            res.y += TransformRaycastLift;
            return res;
        }

        public static Vector3 getPositionRaycastLiftedForLanding(Vector3 position)
        {
            var res = position;
            res.y += TransformRaycastLiftLanding;
            return res;
        }

        public static Vector3 CreateVectorWithoutLoosingYWithMultiplier(Vector3 vector, float y, float multiplier)
        {
            var result = new Vector3(vector.x, 0, vector.z);
            result *= multiplier;
            result.y = y;
            return result;
        }

        public static Vector3 CreateVectorWithoutLoosingY(Vector3 vector, float y)
        {
            return new Vector3(vector.x, y, vector.z);
        }

        public static float CalculateGroundVelocity(Vector3 velocity)
        {
            Vector3 vel = velocity;
            vel.y = 0;
            return vel.magnitude;
        }


        public static Vector3 ModifyYinVector(Vector3 vector, float y)
        {
            var res = vector;
            res.y = y;
            return res;
        }


        public static Vector3 CreateVectorWith0InY(Vector3 vector3)
        {
            return new Vector3(vector3.x, 0, vector3.z);
        }

        public static float getValueInRange(float multiplier, float min, float max)
        {
            return multiplier * (max - min) + max;
        }

        public static float NormalizeValue(float value, float max)
        {
            return Mathf.Abs(value / max);
        }
    }
}