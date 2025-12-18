using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
        }

        public bool Exists(string name)
        {
            return _context.Departments.Any(d => d.Name == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }
        }
    }
}
