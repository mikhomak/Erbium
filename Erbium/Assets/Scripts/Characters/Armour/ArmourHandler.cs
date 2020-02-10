using Characters.Damage;

namespace Characters.Armour {
    public class ArmourHandler: IArmourHandler {

        private readonly IArmour armour;
        public ArmourHandler() {
                        
        }

        public float applyArmour(float damage, DamageType damageType) {
            return armour.applyArmour(damage,damageType);
        }
    }
}