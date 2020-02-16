namespace Characters.Attack {
    public interface IAttackManager {
        void attack();
        void addCombo();
        void resetCombo();
        void setCombo(bool combo);
        bool inCombo();
    }
}