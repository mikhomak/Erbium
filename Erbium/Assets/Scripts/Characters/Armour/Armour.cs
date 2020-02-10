using Characters.Damage;

namespace Characters.Armour {
    public class Armour : IArmour {
        private readonly ICharacter character;

        public Armour(ICharacter character) {
            this.character = character;
        }

        public float applyArmour(float damage, DamageType damageType) {
            float damageAfterApplyingArmour = damage;
            switch (damageType) {
                case DamageType.Physical:
                    damageAfterApplyingArmour -= character.getStats().PhysicArmour;
                    break;
                case DamageType.Magical:
                    damageAfterApplyingArmour -= character.getStats().MagicArmour;
                    break;
                case DamageType.Toxic:
                    damageAfterApplyingArmour -= character.getStats().ToxicArmour;
                    break;
                default:

                    break;
            }

            return damageAfterApplyingArmour;
        }
    }
}