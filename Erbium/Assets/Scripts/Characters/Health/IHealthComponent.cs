using Characters.Damage;

namespace Characters.Health
{
    public interface IHealthComponent
    {
        void TakeDamage(DamageInfo damage);
        void ResetInvincibility();
    }
}