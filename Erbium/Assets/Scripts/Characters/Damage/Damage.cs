namespace Characters.Damage
{
    public struct DamageInfo
    {
        public float damage;
        public readonly DamageType damageType;


        public DamageInfo(float damage, DamageType damageType)
        {
            this.damage = damage;
            this.damageType = damageType;
        }
    }
}