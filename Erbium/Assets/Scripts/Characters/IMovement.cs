namespace Characters {
    public interface IMovement {
        void move();
        void jump();
        void changeMovement(IMovement movement);
    }
}