using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using BLL;
using BLL.Interfaces;
using BLL.Services;


namespace WinFormsUI
{
    public partial class DepartmentForm : Form
    {
        private DepartmentService _departmentService;

        public DepartmentForm()
        {
            InitializeComponent();
            InitializeServices();
            LoadDepartments();
        }

        private void InitializeServices()
        {
            var context = new AppDbContext();
            var repository = new DepartmentRepository(context);
            _departmentService = new DepartmentService(repository);
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = _departmentService.GetAllDepartments();

                dataGridView.Rows.Clear();

                foreach (var dept in departments)
                {
                    dataGridView.Rows.Add(dept.Id, dept.Name, dept.Code);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделов: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new DepartmentAddForm();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string name = addForm.textBoxName.Text;
                    string description = addForm.textBoxCode.Text;

                    _departmentService.AddDepartment(name, description);

                    LoadDepartments();

                    MessageBox.Show("Отдел успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка валидации",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null || dataGridView.CurrentRow.Index < 0)
            {
                MessageBox.Show("Выберите отдел для удаления!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int departmentId = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value);
                string departmentName = dataGridView.CurrentRow.Cells[1].Value.ToString();

                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить отдел \"{departmentName}\"?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _departmentService.DeleteDepartment(departmentId);

                    LoadDepartments();

                    MessageBox.Show("Отдел успешно удален!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении отдела: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
