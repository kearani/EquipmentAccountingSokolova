using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        void Add(Department department);
        bool Exists(string name);
        void Delete(int id);
        void SaveChanges();
    }
}
