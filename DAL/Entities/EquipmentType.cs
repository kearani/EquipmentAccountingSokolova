using DAL.Entities;

namespace DAL.Entities
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}