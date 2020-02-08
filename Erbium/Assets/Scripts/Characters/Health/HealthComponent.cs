using Characters.Damage;
using General;
using UnityEngine;

namespace Characters.Health {
    public class HealthComponent: IHealthComponent {
        private readonly ICharacter character;
        private readonly float invincibilityTime;
        private bool invincibility;
        
        public HealthComponent(ICharacter character) {
            this.character = character;
            invincibilityTime = character.getStats().InvincibilityTime;
        }

        public void takeDamage(DamageInfo damage) {
            if (!invincibility) {
                float currentHealth = character.getStats().Health;
                if (currentHealth - damage.Damage <= 0) {
                    character.die();
                }
                else {
                    character.getStats().Health = currentHealth - damage.Damage;
                }

                invincibility = true;
                TimerManager.Instance.startTimer(invincibilityTime, resetInvincibility);
            }
            
        }

        public void resetInvincibility() {
            invincibility = false;
        }
    }
}