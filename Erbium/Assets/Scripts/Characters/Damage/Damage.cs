namespace Characters.Damage {
    public struct DamageInfo {
        public readonly float Damage;
        public readonly DamageType DamageType;
        public bool IsDot;
        public float DotDuration;

        public DamageInfo(float damage, DamageType damageType, bool isDot = false, float dotDuration = 0) {
            Damage = damage;
            DamageType = damageType;
            IsDot = isDot;
            DotDuration = dotDuration;
        }
    }
}