namespace Characters.Health {
    public class HealthComponent: IHealthComponent {
        private readonly ICharacter character;
        private float invincibilityTimer;

        public HealthComponent(ICharacter character) {
            this.character = character;
        }

        public void takeDamage(float damage) {
            float currentHealth = character.getStats().Health;
            if (currentHealth - damage <= 0) {
                character.die();
            }
            else {
                character.getStats().Health = currentHealth - damage;
            }
        }
    }
}