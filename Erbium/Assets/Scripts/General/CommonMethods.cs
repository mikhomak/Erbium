using UnityEngine;

namespace General {
    public static class CommonMethods {

        private static readonly float groundRayDistance = 0.2f;
        
        public static float calculateMagnitude(float value1, float value2) {
            return Mathf.Clamp01(new Vector2(value1, value2).magnitude);
        }

        public static bool onGround(Transform transform) {
            return Physics.Raycast(transform.position, new Vector3(0,-1), out _, groundRayDistance);
        }

    }
}