using Characters.Damage;

namespace Characters.Armour
{
    public interface IArmour
    {
        float ApplyArmour(float damage, DamageType damageType);
    }
}