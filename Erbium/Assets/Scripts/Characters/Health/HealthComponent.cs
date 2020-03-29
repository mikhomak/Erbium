using Characters.Damage;
using General;

namespace Characters.Health {
    public class HealthComponent : IHealthComponent {
        private readonly ICharacter character;
        private readonly float invincibilityTime;
        private bool invincibility;

        public HealthComponent(ICharacter character) {
            this.character = character;
            invincibilityTime = character.getStats().invincibilityTime;
        }

        public void takeDamage(DamageInfo damage) {
            if (invincibility) return;
            var currentHealth = character.getStats().health -=
                character.getArmour().applyArmour(damage.Damage, damage.DamageType);
            if (currentHealth <= 0) {
                character.getStats().health = 0;
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