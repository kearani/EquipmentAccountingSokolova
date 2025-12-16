using DAL.Entities;

namespace DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}