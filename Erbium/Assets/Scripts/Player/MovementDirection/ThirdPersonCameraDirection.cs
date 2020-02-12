using Camera;
using General;
using UnityEngine;

namespace Player.MovementDirection {
    public class ThirdPersonCameraDirection: IMovementDirection {
        private Transform transform;
        private Vector3 auxDirection;

        public Vector3 getDirection() {
            Vector3 forward = CameraManager.getCameraForwardDirectionNormalized();
            Vector3 right = CameraManager.getCameraRightDirectionNormalized();
            return forward * InputManager.getVerInput() + right * InputManager.getHorInput();
        }

        public void setPlayerTransform(Transform transform) {
            this.transform = transform;
            auxDirection = transform.forward;
        }


        private Vector3 getDirectionPrototype() {
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