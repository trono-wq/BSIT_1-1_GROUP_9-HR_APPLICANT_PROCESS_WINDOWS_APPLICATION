using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmJobVacancyManagement : Form
    {
        // FORMS

        public frmJobVacancyManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;    
        }

        private void frmJobVacancyManagement_Load(object sender, EventArgs e)
        {
            LoadRequirementTypes();
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Open", "Closed" });

            clbQualifications.Items.Clear();
            clbQualifications.Items.Add("Bachelor's Degree");
            clbQualifications.Items.Add("At least one year of work experience");
            clbQualifications.Items.Add("Basic computer literacy");
            clbQualifications.Items.Add("Good communication skills");
            clbQualifications.Items.Add("Team-oriented");

            DatabaseConnection db = new DatabaseConnection();

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                cmbDepartment.DataSource = null;
                cmbDepartment.Items.Clear();

                string departmentQuery = @"SELECT * FROM Departments";
                MySqlCommand departmentCmd = new MySqlCommand(departmentQuery, conn);
                MySqlDataReader departmentReader = departmentCmd.ExecuteReader();
                DataTable departmentTable = new DataTable();

                departmentTable.Load(departmentReader);
                departmentReader.Close();

                cmbDepartment.DataSource = departmentTable;
                cmbDepartment.DisplayMember = "department_name";
                cmbDepartment.ValueMember = "department_id";
                cmbEmploymentType.DataSource = null;
                cmbEmploymentType.Items.Clear();

                string employmentQuery = @"SELECT * FROM EmploymentTypes";
                MySqlCommand employmentCmd = new MySqlCommand(employmentQuery, conn);
                MySqlDataReader employmentReader = employmentCmd.ExecuteReader();

                DataTable employmentTable = new DataTable();
                employmentTable.Load(employmentReader);
                employmentReader.Close();

                cmbEmploymentType.DataSource = employmentTable;
                cmbEmploymentType.DisplayMember = "employment_type_name";
                cmbEmploymentType.ValueMember = "employment_type_id";

                clbQualifications.Items.Clear();
                cmbPosition.DataSource = null;
                cmbPosition.Items.Clear();

                string positionQuery = @"SELECT * FROM PositionTypes";
                MySqlCommand positionCmd = new MySqlCommand(positionQuery, conn);
                MySqlDataReader positionReader = positionCmd.ExecuteReader();
                DataTable positionTable = new DataTable();
                positionTable.Load(positionReader);
                positionReader.Close();
                cmbPosition.DataSource = positionTable;

                cmbPosition.DisplayMember = "position_type_name";
                cmbPosition.ValueMember = "position_type_id";

                string requirementQuery = @"SELECT * FROM RequirementTypes";
                MySqlCommand requirementCmd = new MySqlCommand(requirementQuery, conn);
                MySqlDataReader requirementReader = requirementCmd.ExecuteReader();

                while (requirementReader.Read())
                {
                    clbQualifications.Items.Add(requirementReader["requirement_type_name"].ToString());
                }

                requirementReader.Close();

                if (cmbPosition.Items.Count > 0)
                {
                    cmbPosition.SelectedIndex = -1;
                }   
                if (cmbDepartment.Items.Count > 0)
                {
                    cmbDepartment.SelectedIndex = -1;
                }

                if (cmbEmploymentType.Items.Count > 0)
                {
                    cmbEmploymentType.SelectedIndex = -1;
                }

                if (cmbStatus.Items.Count > 0)
                {
                    cmbStatus.SelectedIndex = -1;
                }
            }

            LoadVacancies();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard HRMAD)
                {
                    HRMAD.ClearHRManagerAdminDashboard();
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        private void frmJobVacancyManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       // BUTTONS

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    if (cmbPosition.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please enter a position.");
                        return;
                    }

                    if (cmbDepartment.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a department.");
                        return;
                    }

                    if (cmbEmploymentType.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select an employment type.");
                        return;
                    }

                    if (cmbStatus.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please select a status.");
                        return;
                    }

                    if (clbQualifications.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select at least one requirement.");
                        return;
                    }

                    if (clbRequiredDocuments.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select at least one document.");
                        return;
                    }

                    string checkQuery = 
                    @"SELECT COUNT(*)
                    FROM JobVacancies
                    WHERE position_type_id  = @positionId
                    AND department_id       = @departmentId
                    AND employment_type_id  = @employmentTypeId";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@positionId", cmbPosition.SelectedValue);
                    checkCmd.Parameters.AddWithValue("@departmentId", cmbDepartment.SelectedValue);
                    checkCmd.Parameters.AddWithValue("@employmentTypeId", cmbEmploymentType.SelectedValue);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This vacancy already exists!");
                        return;
                    }

                    string qualifications = string.Join(", ", clbQualifications.CheckedItems.Cast<object>());
                    string documents = string.Join(", ", clbRequiredDocuments.CheckedItems.Cast<object>());

                    string query = @"INSERT INTO JobVacancies
                    (
                        position_type_id,
                        department_id,
                        employment_type_id,
                        qualifications,
                        required_documents,
                        vacancy_status,
                        o_vacancy_updated_at,
                        o_vacancy_updated_by
                    )

                    VALUES
                    (
                        @position,
                        @departmentId,
                        @employmentTypeId,
                        @qualifications,
                        @requiredDocuments,
                        @status,
                        @updatedAt,
                        @updatedBy
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@position", cmbPosition.SelectedValue);
                    cmd.Parameters.AddWithValue("@departmentId", cmbDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@employmentTypeId", cmbEmploymentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@qualifications", qualifications);
                    cmd.Parameters.AddWithValue("@requiredDocuments", documents);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updatedBy", UserSession.UserId);
                    cmd.ExecuteNonQuery();

                    if (cmbStatus.Text == "Open")
                    {
                        AddAuditTrail("Updated status: Open");
                    }

                    else if (cmbStatus.Text == "Closed")
                    {
                        AddAuditTrail("Updated status: Closed");
                    }

                    if (!string.IsNullOrWhiteSpace(clbQualifications.Text))
                    {
                        AddAuditTrail("Defined qualifications");
                    }

                    if (!string.IsNullOrWhiteSpace(clbRequiredDocuments.Text))
                    {
                        AddAuditTrail("Defined Documents");
                    }

                    AddAuditTrail("Edited postion");
                    MessageBox.Show("Saved Successfully");
                    LoadVacancies();
                    cmbPosition.SelectedIndex = -1;

                    for (int i = 0; i < clbQualifications.Items.Count; i++)
                    {
                        clbQualifications.SetItemChecked(i, false);
                    }

                    for (int i = 0; i < clbRequiredDocuments.Items.Count; i++)
                    {
                        clbRequiredDocuments.SetItemChecked(i, false);
                    }

                    cmbPosition.SelectedIndex       = -1;
                    cmbDepartment.SelectedIndex     = -1;
                    cmbEmploymentType.SelectedIndex = -1;
                    cmbStatus.SelectedIndex         = -1;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    if (selectedVacancyId == 0)
                    {
                        MessageBox.Show("Please select a vacancy first.");
                        return;
                    }
                  
                    if (cmbPosition.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please enter a position.");
                        return;
                    }
                    
                    if (clbQualifications.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select at least one requirement.");
                        return;
                    }

                    if (clbRequiredDocuments.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please select at least one document.");
                        return;
                    }

                    string checkQuery = 
                    @"SELECT COUNT(*)
                    FROM JobVacancies
                    WHERE position_type_id  = @positionId
                    AND department_id       = @departmentId
                    AND employment_type_id  = @employmentTypeId
                    AND job_vacancy_id <> @id";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@positionId", cmbPosition.SelectedValue);
                    checkCmd.Parameters.AddWithValue("@departmentId", cmbDepartment.SelectedValue);
                    checkCmd.Parameters.AddWithValue("@employmentTypeId", cmbEmploymentType.SelectedValue);
                    checkCmd.Parameters.AddWithValue("@id", selectedVacancyId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("This vacancy already exists!");
                        return;
                    }

                    string qualifications = string.Join(", ", clbQualifications.CheckedItems.Cast<object>());
                    string documents = string.Join(", ", clbRequiredDocuments.CheckedItems.Cast<object>());

                    string query = 
                    @"UPDATE JobVacancies SET
                    position_type_id        = @position,
                    department_id           = @departmentId,
                    employment_type_id      = @employmentTypeId,
                    qualifications          = @qualifications,
                    required_documents      = @requiredDocuments,
                    vacancy_status          = @status,
                    o_vacancy_updated_at    = @updatedAt,
                    o_vacancy_updated_by    = @updatedBy
                    WHERE job_vacancy_id    = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@position", cmbPosition.SelectedValue);
                    cmd.Parameters.AddWithValue("@qualifications", qualifications);
                    cmd.Parameters.AddWithValue("@requiredDocuments", documents);
                    cmd.Parameters.AddWithValue("@departmentId", cmbDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@employmentTypeId", cmbEmploymentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@id", selectedVacancyId);
                    cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updatedBy", UserSession.UserId);
                    cmd.ExecuteNonQuery();

                    if (cmbStatus.Text == "Open")
                    {
                        AddAuditTrail(
                        "Updated status: Open");
                    }

                    else if (cmbStatus.Text == "Closed")
                    {
                        AddAuditTrail("Updated status: Closed");
                    }

                    if (!string.IsNullOrWhiteSpace(clbQualifications.Text))
                    {
                        AddAuditTrail("Defined qualifications");
                    }

                    if (!string.IsNullOrWhiteSpace(clbRequiredDocuments.Text))
                    {
                        AddAuditTrail("Defined Documents");
                    }

                    AddAuditTrail("Edited postion");
                    MessageBox.Show("Saved Successfully");
                    LoadVacancies();
                    btnAdd.Enabled = true;
                    selectedVacancyId = 0;
                    cmbPosition.SelectedIndex = -1;

                    for (int i = 0; i < clbQualifications.Items.Count; i++)
                    {
                        clbQualifications.SetItemChecked(i, false);
                    }

                    for (int i = 0; i < clbRequiredDocuments.Items.Count; i++)
                    {
                        clbRequiredDocuments.SetItemChecked(i, false);
                    }

                    cmbPosition.SelectedIndex = -1;
                    cmbDepartment.SelectedIndex     = -1;
                    cmbEmploymentType.SelectedIndex = -1;
                    cmbStatus.SelectedIndex         = -1;

                    txtUpdatedBy.Clear();
                    txtUpdatedAt.Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // OTHERS

        private int selectedVacancyId = 0;

        private void AddAuditTrail(String action)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                    @"INSERT INTO AuditTrail
                    (
                        user_id,
                        action,
                        affected_table,
                        affected_record_id
                    )

                    VALUES
                    (
                        @userId,
                        @action,
                        @table,
                        NULL
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@table", "Job Vacancies");
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadVacancies()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                    @"SELECT
                    j.job_vacancy_id,
                    p.position_type_name,
                    d.department_name,
                    e.employment_type_name,
                    j.qualifications,
                    j.required_documents,
                    j.vacancy_status,
                    j.o_vacancy_updated_at,
                    u.email AS updated_by
                    FROM JobVacancies j

                    LEFT JOIN Departments d
                    ON j.department_id =
                    d.department_id

                    LEFT JOIN EmploymentTypes e
                    ON j.employment_type_id =
                    e.employment_type_id

                    LEFT JOIN Users u
                    ON j.o_vacancy_updated_by =
                    u.user_id

                    LEFT JOIN PositionTypes p
                    ON j.position_type_id =             
                    p.position_type_id";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvVacancies.DataSource = table;
                    dgvVacancies.Columns["job_vacancy_id"].HeaderText = "Job Vacancy ID";
                    dgvVacancies.Columns["position_type_name"].HeaderText = "Position Name";
                    dgvVacancies.Columns["department_name"].HeaderText = "Department";
                    dgvVacancies.Columns["qualifications"].HeaderText = "Requirements";
                    dgvVacancies.Columns["employment_type_name"].HeaderText = "Employment Type";
                    dgvVacancies.Columns["required_documents"].HeaderText = "Documents";
                    dgvVacancies.Columns["vacancy_status"].HeaderText = "Status";
                    dgvVacancies.Columns["o_vacancy_updated_at"].HeaderText = "Updated At";
                    dgvVacancies.Columns["updated_by"].HeaderText = "Updated By";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvVacancies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVacancies.Rows[e.RowIndex];

                if (row.IsNewRow)
                {
                    selectedVacancyId = 0;

                    cmbPosition.SelectedIndex = -1;
                    cmbDepartment.SelectedIndex = -1;
                    cmbEmploymentType.SelectedIndex = -1;
                    cmbStatus.SelectedIndex = -1;

                    txtUpdatedBy.Clear();
                    txtUpdatedAt.Clear();

                    for (int i = 0; i < clbQualifications.Items.Count; i++)
                    {
                        clbQualifications.SetItemChecked(i, false);
                    }

                    for (int i = 0; i < clbRequiredDocuments.Items.Count; i++)
                    {
                        clbRequiredDocuments.SetItemChecked(i, false);
                    }

                    return;
                }

                if (row.Cells["job_vacancy_id"].Value != DBNull.Value)
                {
                    selectedVacancyId = Convert.ToInt32
                    (
                        row.Cells["job_vacancy_id"].Value
                    );
                }

                int positionIndex = cmbPosition.FindStringExact(row.Cells["position_type_name"].Value?.ToString());
                int departmentIndex = cmbDepartment.FindStringExact(row.Cells["department_name"].Value?.ToString());
                int employmentIndex = cmbEmploymentType.FindStringExact(row.Cells["employment_type_name"].Value?.ToString());

                if (positionIndex >= 0)
                {
                    cmbPosition.SelectedIndex = positionIndex;
                }   

                if (departmentIndex >= 0)
                {
                    cmbDepartment.SelectedIndex = departmentIndex;
                }
                
                if (employmentIndex >= 0)
                {
                    cmbEmploymentType.SelectedIndex = employmentIndex;
                }

                clbQualifications.ClearSelected();

                for (int i = 0; i < clbQualifications.Items.Count; i++)
                {
                    clbQualifications.SetItemChecked(i, false);
                }

                string qualificationsText = "";

                if (row.Cells["qualifications"].Value != null)
                {
                    qualificationsText = row.Cells["qualifications"].Value.ToString();
                }

                string[] qualifications = qualificationsText.Split(',');

                foreach (string q in qualifications)
                {
                    for (int i = 0; i < clbQualifications.Items.Count; i++)
                    {
                        if (clbQualifications.Items[i].ToString().Trim() == q.Trim())
                        {
                            clbQualifications.SetItemChecked(i, true);
                        }
                    }
                }

                for (int i = 0; i < clbRequiredDocuments.Items.Count; i++)
                {
                    clbRequiredDocuments.SetItemChecked(i, false);
                }

                string documentsText = "";

                if (row.Cells["required_documents"].Value != null)
                {
                    documentsText = row.Cells["required_documents"].Value.ToString();
                }

                string[] documents = documentsText.Split(',');

                foreach (string d in documents)
                {
                    for (int i = 0; i < clbRequiredDocuments.Items.Count; i++)
                    {
                        if (clbRequiredDocuments.Items[i].ToString().Trim() == d.Trim())
                        {
                            clbRequiredDocuments.SetItemChecked(i, true);
                        }
                    }
                }

                cmbStatus.Text = row.Cells["vacancy_status"].Value?.ToString();
                txtUpdatedBy.Text = row.Cells["updated_by"].Value?.ToString();
                txtUpdatedAt.Text = row.Cells["o_vacancy_updated_at"].Value?.ToString();
                btnAdd.Enabled = true;
            }
        }

        public class RequirementItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        private void LoadRequirementTypes()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM RequirementTypes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    clbQualifications.Items.Clear();
                    while (reader.Read())
                    {
                        clbRequiredDocuments.Items.Add(new RequirementItem
                        {
                            Id = Convert.ToInt32(reader["requirement_type_id"]),
                            Name = reader["requirement_type_name"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}