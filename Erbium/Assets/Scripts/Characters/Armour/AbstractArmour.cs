using Characters.Damage;

namespace Characters.Armour {
    public class AbstractArmour: IArmour {

        private IArmour nextArmour;
        
        public virtual float applyArmour(float damage, DamageType damageType) {
            return nextArmour?.applyArmour(damage, damageType) ?? damage;
        }

        public IArmour setNext(IArmour armour) {
            nextArmour = armour;
            return armour;
        }
    }
}