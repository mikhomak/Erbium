using Camera;
using UnityEngine;

namespace General {
    public class MovementDirection : MonoBehaviour {
        public static Vector3 getCameraForwardDirection() {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            return forward * InputManager.getVerInput() + right * InputManager.getHorInput();
        }
    }
}