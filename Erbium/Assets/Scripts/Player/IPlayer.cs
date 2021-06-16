using Characters;
using Player.MovementDirection;

namespace Player
{
    public interface IPlayer : IPhysicsCharacter
    {
        void ChangeMovementDirection(IMovementDirection movementDirection);
        void ChangeMovementDirection(CameraView cameraView);
    }
}