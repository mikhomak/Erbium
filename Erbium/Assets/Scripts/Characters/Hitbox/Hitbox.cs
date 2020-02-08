using Characters.Damage;
using Characters.Hurtbox;
using General;
using UnityEngine;

namespace Characters.Hitbox {
    public class Hitbox : MonoBehaviour, IHitbox {
        [SerializeField] private IDamageDealer damageDealer;


        private void Start() {
            damageDealer = GetComponentInParent<IDamageDealer>();
        }

        public void OnTriggerEnter(Collider other) {
            if (other.gameObject.layer.Equals(CommonConstants.HURTBOX_LAYER)) {
                var hurtbox = other.GetComponent<IHurtbox>();
                damageDealer.dealDamage(hurtbox);
            }
        }
    }
}