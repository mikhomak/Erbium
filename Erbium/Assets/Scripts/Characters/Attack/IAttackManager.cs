namespace Characters.Attack {
    public interface IAttackManager {
        void attack(bool fast);
        void addCombo();
        void resetCombo();
    }
}