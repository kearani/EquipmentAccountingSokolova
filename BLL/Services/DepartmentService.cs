using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class DepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public List<Department> GetAllDepartments()
        {
            return _repository.GetAll().ToList();
        }

        public void AddDepartment(string name, string code)
        {
            if (_repository.Exists(name))
            {
                throw new ArgumentException("Отдел с таким названием уже существует.");
            }

            var department = new Department
            {
                Name = name,
                Code = code
            };

            _repository.Add(department);
            _repository.SaveChanges();
        }
        public void DeleteDepartment(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
    }
}
