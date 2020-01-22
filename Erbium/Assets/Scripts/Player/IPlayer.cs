using Characters;
using Player.MovementDirection;

namespace Player {
    public interface IPlayer: IPhysicsCharacter {
        void changeMovementDirection(IMovementDirection movementDirection);
        void changeMovementDirection(CameraView cameraView);
    }
}