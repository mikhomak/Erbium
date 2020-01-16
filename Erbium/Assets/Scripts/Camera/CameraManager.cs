using UnityEngine;

namespace Camera {
    public class CameraManager : MonoBehaviour {

        private new static UnityEngine.Camera camera;

        private void Start() {
            camera = UnityEngine.Camera.main;
        }

        public static Vector3 getCameraForwardDirection() {
            return camera.transform.forward;
        }

        public static Vector3 getCameraRightDirection() {
            return camera.transform.right;
        }

        public static Vector3 getCameraForwardDirectionNormalized() {
            Vector3 forward = getCameraForwardDirection();
            forward.y = 0;
            return forward.normalized;
        }

        public static Vector3 getCameraRightDirectionNormalized() {
            Vector3 right = getCameraRightDirection();
            right.y = 0;
            return right.normalized;
        }

    }
}
