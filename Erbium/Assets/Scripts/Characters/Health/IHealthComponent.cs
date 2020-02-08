namespace Characters.Health {
    public interface IHealthComponent {
        void takeDamage(float damage);
        void resetInvincibility();
    }
}