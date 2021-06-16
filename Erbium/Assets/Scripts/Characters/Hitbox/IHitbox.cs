using UnityEngine;

namespace Characters.Hitbox
{
    public interface IHitbox
    {
        void OnTriggerEnter(Collider other);
    }
}