using Characters.Damage;

namespace Characters.Armour {
    public interface IArmourHandler {
        float applyArmour(float damage, DamageType damageType);
    }
}