using Characters.Damage;
using General;

namespace Characters.Health {
    public class HealthComponent : IHealthComponent {
        private readonly ICharacter character;
        private readonly float invincibilityTime;
        private bool invincibility;

        public HealthComponent(ICharacter character) {
            this.character = character;
            invincibilityTime = character.getStats().InvincibilityTime;
        }

        public void takeDamage(DamageInfo damage) {
            if (invincibility) return;
            var currentHealth = character.getStats().Health;
            character.getStats().Health = currentHealth - damage.Damage;
            if (currentHealth - damage.Damage <= 0) {
                character.getStats().Health = 0;
                character.die();
            }

            invincibility = true;
            TimerManager.Instance.startTimer(invincibilityTime, resetInvincibility);
        }

        public void resetInvincibility() {
            invincibility = false;
        }
    }
}