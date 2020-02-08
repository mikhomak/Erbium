using System;
using Characters.Damage;
using Characters.Hurtbox;
using General;
using UnityEngine;

namespace Projectiles {
    public class FireProjectile : MonoBehaviour, IProjectile, IDamageDealer {
        [SerializeField] private float damage;
        [SerializeField] private DamageType damageType;
        private DamageInfo damageInfo;


        private void Start() {
            damageInfo = new DamageInfo(damage, damageType);
        }

        public void move() {
            //TODO move the projectile
            throw new NotImplementedException();
        }


        public void dealDamage(IHurtbox hurtbox) {
            hurtbox.takeDamage(damageInfo);
        }
    }
}