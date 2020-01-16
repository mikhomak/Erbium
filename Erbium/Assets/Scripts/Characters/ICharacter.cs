namespace Characters {
    public interface ICharacter {
        IMovement getMovement();
        void die();
    }
}