using UnityEngine;

namespace Characters.Movement
{
    public interface IMovement
    {
        void setUp();
        void move(Vector3 direction);
        void changeMovement(MovementEnum movement);
        void cleanUp();
    }
}