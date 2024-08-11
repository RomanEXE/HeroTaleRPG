namespace Entities
{
    [System.Serializable]
    public class EntityData
    {
        public int MaxHp;
        public int CurrentHp;
        public int Damage;
        public int Armor;

        public EntityData(EntityDataSo data)
        {
            MaxHp = data.MaxHp;
            CurrentHp = data.CurrentHp;
            Damage = data.Damage;
            Armor = data.Armor;
        }
    }
}