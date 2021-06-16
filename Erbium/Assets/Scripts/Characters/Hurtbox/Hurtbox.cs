using Characters.Damage;
using Characters.Health;
using UnityEngine;

namespace Characters.Hurtbox
{
    public class Hurtbox : MonoBehaviour, IHurtbox
    {
        private ICharacter _character;
        private IHealthComponent _healthComponent;
        [SerializeField] private BodyPartHurtbox bodyPart;


        private void Start()
        {
            _character = GetComponentInParent<ICharacter>();
            _healthComponent = _character.getHealthComponent();
        }


        public void TakeDamage(DamageInfo damageInfo)
        {
            MakeSureHealthComponentIsNotNull();
            damageInfo.damage -= _character.getStats().getBodyPartMultiplier(bodyPart);
            _healthComponent.TakeDamage(damageInfo);
        }

        private void MakeSureHealthComponentIsNotNull()
        {
            if (_healthComponent == null)
            {
                _healthComponent = _character.getHealthComponent();
            }
        }
    }
}