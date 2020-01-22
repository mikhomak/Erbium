using Camera;
using UnityEngine;

namespace General {
    public class ThirdPersonCameraDirection: IMovementDirection  {
        
        public Vector3 getDirection() {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            return forward * InputManager.getVerInput() + right * InputManager.getHorInput();
        }
    }
}