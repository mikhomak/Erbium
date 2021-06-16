using Characters.Damage;

namespace Characters.Armour
{
    public class Armour : IArmour
    {
        private readonly ICharacter _character;

        public Armour(ICharacter character)
        {
            this._character = character;
        }

        public float ApplyArmour(float damage, DamageType damageType)
        {
            return damage - _character.getStats().getArmour(damageType);
        }
    }
}