using Characters.Damage;

namespace Characters.Attack
{
    public interface IAttackManager : IDamageDealer
    {
        void strongAttack();
        void fastAttack();
        void addCombo();
        void resetCombo();
        int getCurrentCombo();
        void createDamageInfo(DamageInfo damageInfo);
    }
}