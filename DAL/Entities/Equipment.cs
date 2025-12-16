namespace DAL.Entities
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }
        public int EquipmentTypeId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public virtual Employee Employee { get; set; }
    }
}