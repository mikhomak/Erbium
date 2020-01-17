using UnityEngine;

namespace General {
    public class CommonMethods {
        public static float calculateMagnitude(float value1, float value2) {
            return Mathf.Clamp01(new Vector2(value1, value2).magnitude);
        }
        
    }
}