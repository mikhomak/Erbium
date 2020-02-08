using Characters.Damage;
using Characters.Health;
using UnityEngine;

namespace Characters.Hurtbox {
    public class Hurtbox : MonoBehaviour, IHurtbox {
        private ICharacter character;
        private IHealthComponent healthComponent;
        [SerializeField] private BodyPartHurtbox bodyPart;


        private void Start() {
            character = GetComponentInParent<ICharacter>();
            healthComponent = character.getHealthComponent();
        }


        public void takeDamage(DamageInfo damageInfo) {
            makeSureHealthComponentIsNotNull();
            healthComponent.takeDamage(damageInfo);
        }

        private void makeSureHealthComponentIsNotNull() {
            if (healthComponent == null) {
                healthComponent = character.getHealthComponent();
            }
        }
    }
}