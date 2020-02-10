using Characters.Damage;

namespace Characters.Armour {
    public class AbstractArmour: IArmour {
        public float applyArmour(float damage, DamageType damageType) {
            throw new System.NotImplementedException();
        }

        public IArmour setNext(IArmour armour) {
            throw new System.NotImplementedException();
        }
    }
}