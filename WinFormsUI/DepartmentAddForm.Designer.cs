namespace WinFormsUI
{
    partial class DepartmentAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxCode = new TextBox();
            label2 = new Label();
            buttonAddForm = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 18);
            label1.Name = "label1";
            label1.Size = new Size(145, 15);
            label1.TabIndex = 0;
            label1.Text = "Название подразделения";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(18, 36);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(176, 23);
            textBoxName.TabIndex = 1;
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(18, 106);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(176, 23);
            textBoxCode.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 88);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 2;
            label2.Text = "Код подразделения";
            // 
            // buttonAddForm
            // 
            buttonAddForm.Location = new Point(53, 150);
            buttonAddForm.Name = "buttonAddForm";
            buttonAddForm.Size = new Size(97, 48);
            buttonAddForm.TabIndex = 4;
            buttonAddForm.Text = "Добавить";
            buttonAddForm.UseVisualStyleBackColor = true;
            // 
            // DepartmentAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(211, 219);
            Controls.Add(buttonAddForm);
            Controls.Add(textBoxCode);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            MaximumSize = new Size(227, 258);
            MinimumSize = new Size(227, 258);
            Name = "DepartmentAddForm";
            Text = "Добавление подразделения";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private TextBox textBoxCode;
        private Label label2;
        private Button buttonAddForm;
    }
}