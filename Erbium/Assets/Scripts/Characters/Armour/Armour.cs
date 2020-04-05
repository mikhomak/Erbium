using Characters.Damage;

namespace Characters.Armour {
    public class Armour : IArmour {
        private readonly ICharacter character;

        public Armour(ICharacter character) {
            this.character = character;
        }

        public float applyArmour(float damage, DamageType damageType) {
            return damage - character.getStats().getArmour(damageType);
        }
    }
}