using Characters.Damage;
using General;

namespace Characters.Health {
    public class HealthComponent : IHealthComponent {
        private readonly ICharacter _character;
        private readonly float _invincibilityTime;
        private bool _invincibility;

        public HealthComponent(ICharacter character) {
            this._character = character;
            _invincibilityTime = character.getStats().invincibilityTime;
        }

        public void TakeDamage(DamageInfo damage) {
            if (_invincibility)
            {
                return;
            }
            
            var currentHealth = _character.getStats().health -=
                _character.getArmour().ApplyArmour(damage.damage, damage.damageType);
            if (currentHealth <= 0) {
                _character.getStats().health = 0;
                _character.Die();
            }

            _invincibility = true;
            // TODO redo this timer shit
            TimerManager.instance.StartTimer(_invincibilityTime, ResetInvincibility);
        }

        public void ResetInvincibility() {
            _invincibility = false;
        }
    }
}