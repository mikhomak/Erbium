using UnityEngine;

namespace Camera {
    public class CameraManager : MonoBehaviour {

        private new static UnityEngine.Camera camera;

        private void Start() {
            camera = UnityEngine.Camera.current;
        }

        static Vector3 getCameraForwardDirection() {
            return camera.transform.forward;
        }

        static Vector3 getCameraRightDirectino() {
            return camera.transform.right;
        }

        static Vector3 getCameraForwardDirectionNormalized() {
            Vector3 forward = getCameraForwardDirection();
            forward.y = 0;
            return forward.normalized;
        }

        static Vector3 getCameraRightDirectionNormalized() {
            Vector3 right = getCameraRightDirectino();
            right.y = 0;
            return right.normalized;
        }

    }
}
