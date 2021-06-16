using UnityEngine;

namespace Characters.Movement
{
    public interface IMovement
    {
        void SetUp();
        void Move(Vector3 direction);
        void ChangeMovement(MovementEnum movement);
        void CleanUp();
    }
}