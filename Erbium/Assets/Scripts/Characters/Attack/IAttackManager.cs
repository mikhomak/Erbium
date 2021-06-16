using Characters.Damage;

namespace Characters.Attack
{
    public interface IAttackManager : IDamageDealer
    {
        void StrongAttack();
        void FastAttack();
        void AddCombo();
        void ResetCombo();
        int getCurrentCombo();
        void CreateDamageInfo(DamageInfo damageInfo);
    }
}