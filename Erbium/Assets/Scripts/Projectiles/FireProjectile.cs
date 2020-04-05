using Characters.Damage;
using Characters.Hurtbox;
using UnityEngine;

namespace Projectiles {
    public class FireProjectile : MonoBehaviour, IProjectile, IDamageDealer {
        [SerializeField] private float damage = 0;
        [SerializeField] private DamageType damageType = DamageType.Physical;
        private DamageInfo damageInfo;


        private void Start() {
            damageInfo = new DamageInfo(damage, damageType);
        }

        public void move() {
            //TODO move the projectile
        }

        public void dealDamage(IHurtbox hurtbox) {
            hurtbox.takeDamage(this.damageInfo);
        }
    }
}