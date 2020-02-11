using Camera;
using General;
using UnityEngine;

namespace Player.MovementDirection {
    public class ThirdPersonCameraDirection: IMovementDirection  {
        Vector3 auxDirection = Vector3.zero;
        public Vector3 getDirection(Transform transform) {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            return forward * InputManager.getVerInput() + right * InputManager.getHorInput();
        }






        private Vector3 getDirectionPrototype(Transform transform) {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            var inputVer = InputManager.getVerInput();
            var inputHor = InputManager.getHorInput();
            
            if (inputVer != 0 && inputHor == 0) {
                auxDirection = transform.right.normalized;
                return inputVer * forward;
            }
            Debug.DrawLine(transform.position, transform.position + auxDirection * 3f);
            Debug.DrawLine(transform.position, transform.position + forward * 3f);
            if (Vector3.Angle(auxDirection, forward) < 20) {
                return inputVer * forward;
            }
            return  auxDirection * inputHor;
        }
    }
}