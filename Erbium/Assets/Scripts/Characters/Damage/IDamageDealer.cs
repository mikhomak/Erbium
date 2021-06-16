using Characters.Hurtbox;

namespace Characters.Damage
{
    public interface IDamageDealer
    {
        void DealDamage(IHurtbox hurtbox);
    }
}