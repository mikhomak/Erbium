using Characters.Damage;

namespace Characters.Hurtbox {
    public class Hurtbox: IHurtbox {

        private ICharacter character;

        public Hurtbox(ICharacter character) {
            this.character = character;
        }


        public void takeDamage(DamageInfo damageInfo) {
        }
    }
}