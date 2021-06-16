using Characters.Hurtbox;

namespace Characters.Damage
{
    public interface IDamageDealer
    {
        void dealDamage(IHurtbox hurtbox);
    }
}