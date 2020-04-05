namespace Characters.Damage {
    public struct DamageInfo {
        public float Damage;
        public readonly DamageType DamageType;


        public DamageInfo(float damage, DamageType damageType) {
            Damage = damage;
            DamageType = damageType;
        }
    }
}  