namespace Characters.Damage {
    public struct DamageInfo {
        public float Damage;
        public DamageType DamageType;
        public bool IsDot;
        public float DotDuration;

        public DamageInfo(float damage, DamageType damageType) {
            Damage = damage;
            DamageType = damageType;
            DotDuration = 0;
        }
    }
}