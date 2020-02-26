using Characters.Damage;

namespace Characters.Attack {
    public interface IAttackManager {
        void strongAttack();
        void addCombo();
        void fastAttack();
        void resetCombo();
        int getCurrentCombo();
        void createDamageInfo(DamageInfo damageInfo);
    }
}