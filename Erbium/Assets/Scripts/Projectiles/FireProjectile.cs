using Characters.Damage;
using Characters.Hurtbox;
using UnityEngine;

namespace Projectiles
{
    public class FireProjectile : MonoBehaviour, IProjectile, IDamageDealer
    {
        [SerializeField] private float damage = 0;
        [SerializeField] private DamageType damageType = DamageType.Physical;
        private DamageInfo _damageInfo;


        private void Start()
        {
            _damageInfo = new DamageInfo(damage, damageType);
        }

        public void Move()
        {
            //TODO move the projectile
            // yeeeah right
        }

        public void DealDamage(IHurtbox hurtbox)
        {
            hurtbox.TakeDamage(this._damageInfo);
        }
    }
}