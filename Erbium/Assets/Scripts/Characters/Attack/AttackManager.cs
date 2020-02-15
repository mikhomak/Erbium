namespace Characters.Attack {
    public class AttackManager: IAttackManager {

        private int currentCombo;
        private bool attacking;
        
        public void attack() {
            
        }

        public void addCombo() {
            attacking = true;
            currentCombo++;
        }

        public void resetCombo() {
            attacking = false;
            currentCombo = 0;
        }
    }
}