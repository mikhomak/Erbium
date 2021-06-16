using UnityEngine;

namespace Characters
{
    public interface IPhysicsCharacter : ICharacter
    {
        Rigidbody getRigidbody();
        Transform getTransform();
    }
}