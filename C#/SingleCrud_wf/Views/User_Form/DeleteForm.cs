using SingleCrud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleCrud
{
    public partial class DeleteForm : Form
    {
        private PersonDatabaseConnection personDatabaseConnection;
        public DeleteForm()
        {
            InitializeComponent();
        }

        /*
           private void InitializeComponent()
           {
               throw new NotImplementedException();
           }
        */
        private void DeleteForm_Load(object sender, EventArgs e)
        {
            this.personDatabaseConnection = new PersonDatabaseConnection("SERVER=localhost;DATABASE=singlecrud;UID=root;PASSWORD=Single");
            this.dataGridView1.DataSource = this.personDatabaseConnection.GetAll();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtNumSocio.ReadOnly = true;
            txtSeniorityPartner.ReadOnly = true;
            txtTypePartner.ReadOnly = true; // tipo de socio
            txtShare.ReadOnly = true; // Cuota del socio
            txtPost.ReadOnly = true; // Cargo del socio
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtDni.ReadOnly = true; // Dni del socio
            txtAge.ReadOnly = true;
            txtFamilyUnity.ReadOnly = true;
            txtHeredaSitio.ReadOnly = true; // Hereda sitio
            txtTelefPrimary.ReadOnly = true;
            txtTelefSecondary.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtLocation.ReadOnly = true;
            txtAdress.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";
                btnDelete.Visible = false;
                txtNumSocio.ReadOnly = false;
                txtSeniorityPartner.ReadOnly = false;
                txtTypePartner.ReadOnly = false; // tipo de socio
                txtShare.ReadOnly = false; // Cuota del socio
                txtPost.ReadOnly = false; // Cargo del socio
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                txtDni.ReadOnly = false; // Dni del socio
                txtAge.ReadOnly = false;
                txtFamilyUnity.ReadOnly = false;
                txtHeredaSitio.ReadOnly = false; // Hereda sitio
                txtTelefPrimary.ReadOnly = false;
                txtTelefSecondary.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtLocation.ReadOnly = false;
                txtAdress.ReadOnly = false;
            }
            else
            {
                var row = dataGridView1.SelectedRows[0];
                int age = 0;
                if (int.TryParse(txtAge.Text, out age))
                {
                    var person = new Person
                    {
                        Id = int.Parse(row.Cells[0].Value.ToString()),
                        Num_Socio = int.Parse(row.Cells[1].Value.ToString()),
                        Seniority_Partner = int.Parse(row.Cells[2].Value.ToString()),
                        Type_Partner = txtTypePartner.Text,
                        Share = int.Parse(row.Cells[4].Value.ToString()),
                        Post = txtPost.Text,
                        First_Name = txtFirstName.Text,
                        Last_Name = txtLastName.Text,
                        Dni = int.Parse(row.Cells[8].Value.ToString()),
                        Age = age,
                        Family_Unity = int.Parse(row.Cells[10].Value.ToString()),
                        Hereda_Sitio = txtHeredaSitio.Text,
                        Telef_Primary = int.Parse(row.Cells[12].Value.ToString()),
                        Telef_Secondary = int.Parse(row.Cells[13].Value.ToString()),
                        Email = txtEmail.Text,
                        Location = txtLocation.Text,
                        Adress = txtAdress.Text,
                    };

                    this.personDatabaseConnection.Update(person);
                    btnUpdate.Text = "Update";
                    btnDelete.Visible = true;

                    txtNumSocio.ReadOnly = true;
                    txtSeniorityPartner.ReadOnly = true;
                    txtTypePartner.ReadOnly = true; // tipo de socio
                    txtShare.ReadOnly = true; // Cuota del socio
                    txtPost.ReadOnly = true; // Cargo del socio
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtDni.ReadOnly = true; // Dni del socio
                    txtAge.ReadOnly = true;
                    txtFamilyUnity.ReadOnly = true;
                    txtHeredaSitio.ReadOnly = true; // Hereda sitio
                    txtTelefPrimary.ReadOnly = true;
                    txtTelefSecondary.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtLocation.ReadOnly = true;
                    txtAdress.ReadOnly = true;

                    this.dataGridView1.DataSource = this.personDatabaseConnection.GetAll();
                }
                else
                {
                    MessageBox.Show("Invalid age.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show
                (
                string.Format("Are you sure you want to remove  {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}",
                txtNumSocio.Text,
                txtSeniorityPartner.Text,
                txtTypePartner.Text,
                txtShare.Text,
                txtPost.Text,
                txtFirstName.Text,
                txtLastName.Text,
                txtDni.Text,
                txtAge.Text,
                txtFamilyUnity.Text,
                txtHeredaSitio.Text,
                txtTelefPrimary.Text,
                txtTelefSecondary.Text,
                txtEmail.Text,
                txtLocation.Text,
                txtAdress.Text
                ),
                "Remove Person",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

            if (dialogResult == DialogResult.Yes)
            {
                var row = dataGridView1.SelectedRows[0];
                this.personDatabaseConnection.Delete(int.Parse(row.Cells[0].Value.ToString()));
                this.dataGridView1.DataSource = this.personDatabaseConnection.GetAll();

                txtNumSocio.Text = string.Empty;
                txtSeniorityPartner.Text = string.Empty;
                txtTypePartner.Text = string.Empty;
                txtShare.Text = string.Empty;
                txtPost.Text = string.Empty;   
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtDni.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtFamilyUnity.Text = string.Empty;
                txtHeredaSitio.Text = string.Empty;
                txtTelefPrimary.Text = string.Empty;
                txtTelefSecondary.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtLocation.Text = string.Empty;
                txtAdress.Text = string.Empty;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            btnUpdate.Text = "Update";
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnDelete.Visible = true;

            txtNumSocio.ReadOnly = true;
            txtSeniorityPartner.ReadOnly = true;
            txtTypePartner.ReadOnly = true; // tipo de socio
            txtShare.ReadOnly = true; // Cuota del socio
            txtPost.ReadOnly = true; // Cargo del socio
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtDni.ReadOnly = true; // Dni del socio
            txtAge.ReadOnly = true;
            txtFamilyUnity.ReadOnly = true;
            txtHeredaSitio.ReadOnly = true; // Hereda sitio
            txtTelefPrimary.ReadOnly = true;
            txtTelefSecondary.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtLocation.ReadOnly = true;
            txtAdress.ReadOnly = true;

            txtNumSocio.Text = row.Cells[1].Value.ToString();
            txtSeniorityPartner.Text = row.Cells[2].Value.ToString();
            txtTypePartner.Text = row.Cells[3].Value.ToString();
            txtShare.Text = row.Cells[4].Value.ToString();
            txtPost.Text = row.Cells[5].Value.ToString();
            txtFirstName.Text = row.Cells[6].Value.ToString();
            txtLastName.Text = row.Cells[7].Value.ToString();
            txtDni.Text = row.Cells[8].Value.ToString();
            txtAge.Text = row.Cells[9].Value.ToString();
            txtFamilyUnity.Text = row.Cells[10].Value.ToString();
            txtHeredaSitio.Text = row.Cells[11].Value.ToString();
            txtTelefPrimary.Text = row.Cells[12].Value.ToString();
            txtTelefSecondary.Text = row.Cells[13].Value.ToString();
            txtEmail.Text = row.Cells[14].Value.ToString();
            txtLocation.Text = row.Cells[15].Value.ToString();
            txtAdress.Text = row.Cells[16].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScreenShotForm frm = new ScreenShotForm();
            frm.Show();// 

        }
    }
}


