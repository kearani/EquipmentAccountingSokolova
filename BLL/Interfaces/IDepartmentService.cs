using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentsAsync();
        Task<int> AddDepartmentAsync(Department department);
    }
}
