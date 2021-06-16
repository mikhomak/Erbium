using Characters.Damage;

namespace Characters.Hurtbox
{
    public interface IHurtbox
    {
        void TakeDamage(DamageInfo damageInfo);
    }
}