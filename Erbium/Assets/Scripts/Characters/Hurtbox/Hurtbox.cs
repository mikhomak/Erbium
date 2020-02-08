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

        private void makeSureHealthComponentIsNotNull() {
            if (healthComponent == null) {
                healthComponent = character.getHealthComponent();
            }
        }
    }
}