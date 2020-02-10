using Characters.Damage;

namespace Characters.Armour {
    public interface IArmour {
        float applyArmour(float damage, DamageType damageType);
    }
}