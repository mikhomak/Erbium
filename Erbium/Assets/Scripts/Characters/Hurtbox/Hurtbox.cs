using Characters.Damage;

namespace Characters.Hurtbox {
    public class Hurtbox : IHurtbox {
        private ICharacter character;

        public Hurtbox(ICharacter character) {
            this.character = character;
        }


        public void takeDamage(DamageInfo damageInfo) {
            var healthComponent = character.getHealthComponent();
            switch (damageInfo.DamageType) {
                case DamageType.Physical:
                    healthComponent.takeDamage(damageInfo.Damage - character.getStats().PhysicArmour);
                    break;
                case DamageType.Magical:
                    healthComponent.takeDamage(damageInfo.Damage - character.getStats().MagicArmour);
                    break;
                case DamageType.Toxic:
                    healthComponent.takeDamage(damageInfo.Damage - character.getStats().ToxicArmour);
                    break;
            }
        }
    }
}