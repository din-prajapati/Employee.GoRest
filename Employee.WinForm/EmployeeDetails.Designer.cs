
namespace Employee.WinForm
{
    partial class frmEmployeeDetails
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblEmployeeID = new Label();
            txtEmployeeID = new TextBox();
            txtEmployeeName = new TextBox();
            lblEmployeeName = new Label();
            lblGender = new Label();
            radMale = new RadioButton();
            radFemale = new RadioButton();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtStatus = new TextBox();
            lblStatus = new Label();
            btnFindById = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dgvEmployeeDetails = new DataGridView();
            btnFirst = new Button();
            btnPagePrevious = new Button();
            btnNext = new Button();
            btnLast = new Button();
            txtPageNumber = new TextBox();
            panel1 = new Panel();
            btnClear = new Button();
            label1 = new Label();
            btnExportCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeDetails).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblEmployeeID
            // 
            lblEmployeeID.AutoSize = true;
            lblEmployeeID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeeID.Location = new Point(12, 21);
            lblEmployeeID.Name = "lblEmployeeID";
            lblEmployeeID.Size = new Size(77, 15);
            lblEmployeeID.TabIndex = 0;
            lblEmployeeID.Text = "Employee ID";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Location = new Point(112, 18);
            txtEmployeeID.MaxLength = 10;
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(117, 23);
            txtEmployeeID.TabIndex = 1;
            txtEmployeeID.TextChanged += txtEmployeeID_TextChanged;
            txtEmployeeID.KeyPress += txtEmployeeID_KeyPress;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(112, 57);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(230, 23);
            txtEmployeeName.TabIndex = 3;
            txtEmployeeName.KeyPress += txtEmployeeName_KeyPress;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeeName.Location = new Point(12, 60);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(97, 15);
            lblEmployeeName.TabIndex = 2;
            lblEmployeeName.Text = "Employee Name";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGender.Location = new Point(12, 99);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(49, 15);
            lblGender.TabIndex = 4;
            lblGender.Text = "Gender";
            // 
            // radMale
            // 
            radMale.AutoSize = true;
            radMale.Location = new Point(112, 97);
            radMale.Name = "radMale";
            radMale.Size = new Size(51, 19);
            radMale.TabIndex = 6;
            radMale.TabStop = true;
            radMale.Text = "Male";
            radMale.UseVisualStyleBackColor = true;
            // 
            // radFemale
            // 
            radFemale.AutoSize = true;
            radFemale.Location = new Point(178, 97);
            radFemale.Name = "radFemale";
            radFemale.Size = new Size(63, 19);
            radFemale.TabIndex = 7;
            radFemale.TabStop = true;
            radFemale.Text = "Female";
            radFemale.UseVisualStyleBackColor = true;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(112, 131);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(286, 23);
            txtEmail.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(12, 134);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(112, 176);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(154, 23);
            txtStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(12, 179);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            // 
            // btnFindById
            // 
            btnFindById.Location = new Point(262, 17);
            btnFindById.Name = "btnFindById";
            btnFindById.Size = new Size(75, 23);
            btnFindById.TabIndex = 12;
            btnFindById.Text = "Find by Employee ID";
            btnFindById.UseVisualStyleBackColor = true;
            btnFindById.Click += btnFindById_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(9, 238);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(97, 23);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(132, 238);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(97, 23);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(262, 238);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(97, 23);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvEmployeeDetails
            // 
            dgvEmployeeDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployeeDetails.Dock = DockStyle.Fill;
            dgvEmployeeDetails.Location = new Point(0, 0);
            dgvEmployeeDetails.Name = "dgvEmployeeDetails";
            dgvEmployeeDetails.Size = new Size(741, 267);
            dgvEmployeeDetails.TabIndex = 17;
            dgvEmployeeDetails.CellClick += dgvEmployeeDetails_CellClick;
            // 
            // btnFirst
            // 
            btnFirst.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFirst.Location = new Point(141, 573);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(72, 23);
            btnFirst.TabIndex = 18;
            btnFirst.Text = "First Page";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPagePrevious
            // 
            btnPagePrevious.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPagePrevious.Location = new Point(219, 573);
            btnPagePrevious.Name = "btnPagePrevious";
            btnPagePrevious.Size = new Size(97, 23);
            btnPagePrevious.TabIndex = 19;
            btnPagePrevious.Text = "<< Previous Page";
            btnPagePrevious.UseVisualStyleBackColor = true;
            btnPagePrevious.Click += btnPagePrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.Location = new Point(376, 573);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(97, 23);
            btnNext.TabIndex = 20;
            btnNext.Text = "Next Page >>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLast.Location = new Point(479, 573);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(97, 23);
            btnLast.TabIndex = 21;
            btnLast.Text = "Last Page";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // txtPageNumber
            // 
            txtPageNumber.Location = new Point(322, 574);
            txtPageNumber.MaxLength = 5;
            txtPageNumber.Name = "txtPageNumber";
            txtPageNumber.ShortcutsEnabled = false;
            txtPageNumber.Size = new Size(48, 23);
            txtPageNumber.TabIndex = 22;
            txtPageNumber.TextChanged += txtPageNumber_TextChanged;
            txtPageNumber.KeyPress += txtPageNumber_KeyPress;
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvEmployeeDetails);
            panel1.Location = new Point(12, 285);
            panel1.Name = "panel1";
            panel1.Size = new Size(741, 267);
            panel1.TabIndex = 23;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.Location = new Point(393, 238);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(97, 23);
            btnClear.TabIndex = 24;
            btnClear.Text = "Reset";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 58);
            label1.Name = "label1";
            label1.Size = new Size(307, 15);
            label1.TabIndex = 25;
            label1.Text = "( Type Name and Hit Enter to Search by Employee Name)";
            // 
            // btnExportCSV
            // 
            btnExportCSV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportCSV.Location = new Point(658, 238);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(95, 23);
            btnExportCSV.TabIndex = 26;
            btnExportCSV.Text = "Export to Excel";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // frmEmployeeDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 612);
            Controls.Add(btnExportCSV);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(panel1);
            Controls.Add(txtPageNumber);
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(btnPagePrevious);
            Controls.Add(btnFirst);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnFindById);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(radFemale);
            Controls.Add(radMale);
            Controls.Add(lblGender);
            Controls.Add(txtEmployeeName);
            Controls.Add(lblEmployeeName);
            Controls.Add(txtEmployeeID);
            Controls.Add(lblEmployeeID);
            MaximizeBox = false;
            Name = "frmEmployeeDetails";
            Text = "Employee Detail";
            Load += frmEmployeeDetails_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployeeDetails).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEmployeeID;
        private TextBox txtEmployeeID;
        private TextBox txtEmployeeName;
        private Label lblEmployeeName;
        private Label lblGender;
        private RadioButton radMale;
        private RadioButton radFemale;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtStatus;
        private Label lblStatus;
        private Button btnFindById;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dgvEmployeeDetails;
        private Button btnFirst;
        private Button btnPagePrevious;
        private Button btnNext;
        private Button btnLast;
        private TextBox txtPageNumber;
        private Panel panel1;
        private Button btnClear;
        private Label label1;
        private Button btnExportCSV;
    }
}
