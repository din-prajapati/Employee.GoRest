using Employee.Core.Common;
using Employee.Core.Service.Interfaces;
using Employee.Core.Service.Models;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Text;

namespace Employee.WinForm
{
    public partial class frmEmployeeDetails : Form
    {
        private readonly IEmployeeService _employeeService;
        private int currentPageIndex = 1;
        private int totalPage = 0;

        private EmployeeDetailsItem mEmployeeDetails = new EmployeeDetailsItem();

        private int employeeID;
        public frmEmployeeDetails(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        /// <summary>
        /// Load Event of Employee Details Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmEmployeeDetails_Load(object sender, EventArgs e)
        {
            btnExportCSV.Enabled = false;
            await GetEmployees();
            txtPageNumber.Text = currentPageIndex.ToString();
        }

        /// <summary>
        /// Used to get all employees
        /// </summary>
        /// <returns></returns>
        private async Task GetEmployees()
        {
            try
            {
                EmployeeListItem mEmployeeList = await _employeeService.GetEmployees();
                dgvEmployeeDetails.DataSource = mEmployeeList.Entities;
                totalPage = mEmployeeList.TotalPageCount;
                currentPageIndex = 1;
                btnExportCSV.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching Employee List." + ex.Message, "Employee Details");
            }
        }

        /// <summary>
        /// Used to get employees by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task GetEmployeesByName(string name)
        {
            try
            {
                EmployeeListItem mEmployeeList = await _employeeService.GetEmployees(name);
                dgvEmployeeDetails.DataSource = mEmployeeList.Entities;
                totalPage = mEmployeeList.TotalPageCount;
                currentPageIndex = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching Employee List." + ex.Message, "Employee Details");
            }
        }

        /// <summary>
        /// Used to get employees by specific page number. 
        /// Note : if page number does not exist then it will return last page details
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private async Task GetEmployees(int page)
        {
            try
            {
                EmployeeListItem mEmployeeList = await _employeeService.GetEmployees(page);
                dgvEmployeeDetails.DataSource = mEmployeeList.Entities;
                totalPage = mEmployeeList.TotalPageCount;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching Employee List." + ex.Message, "Employee Details");
            }

        }

        /// <summary>
        /// Used to get employees by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task GetEmployeeById(long id)
        {
            try
            {
                mEmployeeDetails = await _employeeService.GetEmployeeById(id);
                AssignControls(mEmployeeDetails);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching Employee Details." + ex.Message, "Employee Details");
            }

        }

        /// <summary>
        /// Assign employee details to controls
        /// </summary>
        /// <param name="employeeDetails"></param>
        private void AssignControls(EmployeeDetailsItem employeeDetails)
        {
            if (employeeDetails.Entity != null)
            {
                txtEmployeeID.Text = employeeDetails.Entity.Id.ToString();
                txtEmployeeName.Text = employeeDetails.Entity.Name.ToString();
                if (employeeDetails.Entity.Gender.ToString().ToLower() == "male".ToString().ToLower())
                {
                    radMale.Checked = true;
                }
                else
                {
                    radFemale.Checked = true;
                }
                txtStatus.Text = employeeDetails.Entity.Status.ToString();
                txtEmail.Text = employeeDetails.Entity.Email.ToString();
            }
        }

        /// <summary>
        /// Used to create employee detail object from control values
        /// </summary>
        private void SetEmployeeDetails()
        {
            if (mEmployeeDetails.Entity != null)
            {
                mEmployeeDetails.Entity.Id = Convert.ToInt64((!string.IsNullOrEmpty(txtEmployeeID.Text) ? txtEmployeeID.Text : 0));
                mEmployeeDetails.Entity.Name = txtEmployeeName.Text;
                if (radMale.Checked)
                {
                    mEmployeeDetails.Entity.Gender = "Male".ToString().ToLower();
                }
                else
                {
                    mEmployeeDetails.Entity.Gender = "Female".ToString().ToLower();
                }
                mEmployeeDetails.Entity.Status = txtStatus.Text;
                mEmployeeDetails.Entity.Email = txtEmail.Text;
            }
        }

        /// <summary>
        /// Used to reset employee details form.
        /// </summary>
        private void ClearControls()
        {
            txtEmployeeID.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            radMale.Checked = false;
            radFemale.Checked = false;
            txtStatus.Text = string.Empty;
            txtEmail.Text = string.Empty;

            mEmployeeDetails = new EmployeeDetailsItem();
            employeeID = 0;
        }

        /// <summary>
        /// Find by Employee id Click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFindById_Click(object sender, EventArgs e)
        {
            long id = Convert.ToInt64(txtEmployeeID.Text);
            await GetEmployeeById(id);
        }

        /// <summary>
        /// First page button click event handler. used to navigate to first page of grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnFirst_Click(object sender, EventArgs e)
        {
            this.currentPageIndex = 1;
            txtPageNumber.Text = currentPageIndex.ToString();
            await GetEmployees(this.currentPageIndex);
        }

        /// <summary>
        /// Previous page button click event handler. used to navigate to previous page of grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnPagePrevious_Click(object sender, EventArgs e)
        {
            if (this.currentPageIndex > 1)
            {
                this.currentPageIndex--;
                txtPageNumber.Text = currentPageIndex.ToString();
                await GetEmployees(this.currentPageIndex);
            }
        }
        /// <summary>
        /// Next page button click event handler. used to navigate to next page of grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (this.currentPageIndex < this.totalPage)
            {
                this.currentPageIndex++;
                txtPageNumber.Text = currentPageIndex.ToString();
                await GetEmployees(this.currentPageIndex);
            }
        }

        /// <summary>
        /// Last page button click event handler. used to navigate to last page of grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLast_Click(object sender, EventArgs e)
        {
            this.currentPageIndex = totalPage;
            txtPageNumber.Text = currentPageIndex.ToString();
            await GetEmployees(this.currentPageIndex);
        }

        /// <summary>
        /// Page number keypress event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtPageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
            {
                currentPageIndex = Convert.ToInt32(txtPageNumber.Text);
                if (this.currentPageIndex > this.totalPage)
                {
                    this.currentPageIndex = this.totalPage;
                    txtPageNumber.Text = currentPageIndex.ToString();
                }
                await GetEmployees(this.currentPageIndex);
            }
        }
        /// <summary>
        /// Employee id key press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtEmployeeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
            {
                long id = Convert.ToInt64(txtEmployeeID.Text);
                await GetEmployeeById(id);
            }
        }

        /// <summary>
        /// Reset button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
            await GetEmployees();
        }

        /// <summary>
        /// Save button Click event handler. Used to add employee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetEmployeeDetails();
                if (mEmployeeDetails.Entity != null)
                {
                    mEmployeeDetails = await _employeeService.AddEmployee(mEmployeeDetails.Entity);
                    if (mEmployeeDetails.Entity != null && (mEmployeeDetails.Entity.ValidationFieldMessage != null && mEmployeeDetails.Entity.ValidationFieldMessage.Count > 0))
                    {
                        string validationMessage = getValidationMessage(mEmployeeDetails.Entity.ValidationFieldMessage);
                        MessageBox.Show(validationMessage.ToString(), "Employee Details");
                    }
                    else
                    {
                        MessageBox.Show("Employee added successfully.", "Employee Details");
                    }
                    await GetEmployees();
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving Employee Details." + ex.Message, "Employee Details");
            }

        }
        /// <summary>
        /// Used to prepare validation message based on API response.
        /// </summary>
        /// <param name="ValidationFieldMessage"></param>
        /// <returns></returns>
        private string getValidationMessage(List<ValidationApiFieldMessage> ValidationFieldMessage)
        {
            StringBuilder validationMessage = new StringBuilder();
            validationMessage.Append("Employee not able to save. Please look following validations.");
            validationMessage.Append(System.Environment.NewLine);
            validationMessage.Append(System.Environment.NewLine);
            foreach (var item in ValidationFieldMessage)
            {
                validationMessage.Append("\t" + item.Field + " " + item.Message);
                validationMessage.Append(System.Environment.NewLine);
            }
            return validationMessage.ToString();
        }

        /// <summary>
        /// Update button click event handler. Used to update employee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SetEmployeeDetails();
                if (mEmployeeDetails.Entity != null)
                {
                    mEmployeeDetails = await _employeeService.UpdateEmployee(mEmployeeDetails.Entity.Id, mEmployeeDetails.Entity);
                    if (mEmployeeDetails.Entity != null && (mEmployeeDetails.Entity.ValidationFieldMessage != null && mEmployeeDetails.Entity.ValidationFieldMessage.Count > 0))
                    {
                        string validationMessage = getValidationMessage(mEmployeeDetails.Entity.ValidationFieldMessage);
                        MessageBox.Show(validationMessage.ToString(), "Employee Details");
                    }
                    else
                    {
                        MessageBox.Show("Employee updated successfully.", "Employee Details");
                    }
                    await GetEmployees();
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving Employee Details." + ex.Message, "Employee Details");
            }

        }

        /// <summary>
        /// Delete button event handler. Used to delete employee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (employeeID > 0)
                {
                    bool success = await _employeeService.DeleteEmployee(employeeID);
                    if (success)
                    {
                        MessageBox.Show("Employee deleted successfully.", "Employee Details");
                        await GetEmployees();
                        employeeID = 0;
                    }
                    else
                    {
                        MessageBox.Show("Error while saving deleting Employee.", "Employee Details");
                    }
                }
                else
                {
                    MessageBox.Show("Please select record from grid in order to delete.", "Employee Details");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting Employee Details." + ex.Message, "Employee Details");
            }

        }

        /// <summary>
        /// Grid Cell click event handler. Used to select employee detail row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployeeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployeeDetails.Rows.Count > 0)
            {
                DataGridViewRow dgRow = dgvEmployeeDetails.Rows[e.RowIndex];
                if (dgRow != null)
                {
                    employeeID = Convert.ToInt32(dgRow.Cells[0].Value);
                }
            }

        }

        /// <summary>
        /// Employee Name keypress event handler. Used to get employee list by employee name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void txtEmployeeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Return)
            {
                if (!string.IsNullOrEmpty(txtEmployeeName.Text))
                {
                    await GetEmployeesByName(txtEmployeeName.Text);
                }
                else
                {
                    await GetEmployees();
                }

            }
        }

        /// <summary>
        /// Export to CSV button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            if (dgvEmployeeDetails.Rows.Count == 0)
            {
                MessageBox.Show("No records to export.", "Employee Details");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = "EmployeeDetails.csv";
            saveDialog.Filter = "CSV files (*.CSV)|*.CSV|All files (*.*)|*.*";

            DialogResult result = saveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String fileName = saveDialog.FileName;
                exportToCSV(fileName);
                MessageBox.Show("Employee details exported at following location : " + fileName, "Employee Details");
            }
        }

        /// <summary>
        /// Used to create CSV file based on Grid data.
        /// </summary>
        /// <param name="fileName"></param>
        private void exportToCSV(string fileName)
        {
            try
            {
                using (StreamWriter csv = new StreamWriter(fileName, false))
                {
                    int totalcolms = dgvEmployeeDetails.ColumnCount;
                    foreach (DataGridViewColumn colm in dgvEmployeeDetails.Columns) csv.Write(colm.HeaderText + ',');
                    csv.Write('\n');
                    string data = "";
                    foreach (DataGridViewRow row in dgvEmployeeDetails.Rows)
                    {
                        if (row.IsNewRow) continue;
                        data = "";
                        for (int i = 0; i < totalcolms; i++)
                        {
                            data += (row.Cells[i].Value ?? "").ToString() + ',';
                        }
                        if (data != string.Empty) csv.WriteLine(data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while exporting Employee Details." + ex.Message, "Employee Details");
            }


        }

        /// <summary>
        /// Employee ID Text changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {
            if (txtEmployeeID.Text.Length >= txtEmployeeID.MaxLength)
            {
                txtEmployeeID.Text = txtEmployeeID.Text.Substring(0, txtEmployeeID.MaxLength);
            }
        }
        /// <summary>
        /// PageNumber Text changed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPageNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtPageNumber.Text.Length >= txtPageNumber.MaxLength)
            {
                txtPageNumber.Text = txtPageNumber.Text.Substring(0, txtPageNumber.MaxLength);
            }
        }
    }
}
