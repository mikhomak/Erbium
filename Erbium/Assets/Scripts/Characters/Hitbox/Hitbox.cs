using Characters.Damage;
using Characters.Hurtbox;
using General;
using UnityEngine;

namespace Characters.Hitbox
{
    public class Hitbox : MonoBehaviour, IHitbox
    {
        private IDamageDealer _damageDealer;


        private void Start()
        {
            _damageDealer = GetComponentInParent<IDamageDealer>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer.Equals(CommonConstants.HurtboxLayer))
            {
                var hurtbox = other.GetComponent<IHurtbox>();
                _damageDealer.DealDamage(hurtbox);
            }
        }
    }
}