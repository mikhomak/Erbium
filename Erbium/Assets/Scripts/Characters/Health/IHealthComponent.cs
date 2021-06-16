using Characters.Damage;

namespace Characters.Health
{
    public interface IHealthComponent
    {
        void takeDamage(DamageInfo damage);
        void resetInvincibility();
    }
}