using Characters.Damage;
namespace Characters.Hurtbox {
    public interface IHurtbox {
        void takeDamage(DamageInfo damageInfo);
    }
}