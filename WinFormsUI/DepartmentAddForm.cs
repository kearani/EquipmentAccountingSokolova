using BLL.Services;
using DAL;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsUI
{
    public partial class DepartmentAddForm : Form
    {
        private ErrorProvider errorProvider1;
        public DepartmentAddForm()
        {
            InitializeComponent();
            SetupValidation();
        }

        private void SetupValidation()
        {
            textBoxName.Validating += TextBoxName_Validating;

            this.FormClosing += DepartmentAddForm_FormClosing;
        }

        private void TextBoxName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                errorProvider1.SetError(textBoxName, "Введите название отдела");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxName, "");
            }
        }

        private void DepartmentAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("Название отдела обязательно для заполнения!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    textBoxName.Focus();
                }
            }
        }

    }
}
