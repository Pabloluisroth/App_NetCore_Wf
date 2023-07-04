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
    public partial class ModifyForm : Form
    {
        private PersonDatabaseConnection personDatabaseConnection;
        public ModifyForm()
        {
            InitializeComponent();
        }

     /*
        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
     */
        private void ModifyForm_Load(object sender, EventArgs e)
        {
            this.personDatabaseConnection = new PersonDatabaseConnection("SERVER=localhost;DATABASE=singlecrud;UID=root;PASSWORD=Single");
            this.dataGridView1.DataSource = this.personDatabaseConnection.GetAll();
            btnUpdate.Enabled            = false;
            txtNumSocio.ReadOnly         = true;
            txtSeniorityPartner.ReadOnly = true;
            txtTypePartner.ReadOnly      = true; // tipo de socio
            txtShare.ReadOnly            = true; // Cuota del socio
            txtPost.ReadOnly             = true; // Cargo del socio
            txtFirstName.ReadOnly        = true;
            txtLastName.ReadOnly         = true;
            txtDni.ReadOnly              = true; // Dni del socio
            txtAge.ReadOnly              = true;
            txtFamilyUnity.ReadOnly      = true;
            txtHeredaSitio.ReadOnly      = true; // Hereda sitio
            txtTelefPrimary.ReadOnly     = true;
            txtTelefSecondary.ReadOnly   = true;
            txtEmail.ReadOnly            = true;
            txtLocation.ReadOnly         = true;
            txtAdress.ReadOnly           = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text == "Update")
            {
                btnUpdate.Text = "Save";

                txtNumSocio.ReadOnly        = false;
                txtSeniorityPartner.ReadOnly= false;
                txtTypePartner.ReadOnly     = false;
                txtShare.ReadOnly           = false;
                txtPost.ReadOnly            = false;
                txtFirstName.ReadOnly       = false;
                txtLastName.ReadOnly        = false;
                txtDni.ReadOnly             = false;
                txtAge.ReadOnly             = false;
                txtFamilyUnity.ReadOnly     = false;
                txtHeredaSitio.ReadOnly     = false;
                txtTelefPrimary.ReadOnly    = false;
                txtTelefSecondary.ReadOnly  = false;
                txtEmail.ReadOnly           = false;
                txtLocation.ReadOnly        = false;
                txtAdress.ReadOnly          = false;
            }
            else
            {            
                var row = dataGridView1.SelectedRows[0]; // 
                int age = 0;

                if(int.TryParse(txtAge.Text, out age))
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
                    btnUpdate.Text    = "Update";

                    txtNumSocio.ReadOnly        = true;
                    txtSeniorityPartner.ReadOnly= true;
                    txtTypePartner.ReadOnly     = true;
                    txtShare.ReadOnly           = true;
                    txtPost.ReadOnly            = true;
                    txtFirstName.ReadOnly       = true;
                    txtLastName.ReadOnly        = true;
                    txtDni.ReadOnly             = true;
                    txtAge.ReadOnly             = true;
                    txtFamilyUnity.ReadOnly     = true;
                    txtHeredaSitio.ReadOnly     = true;
                    txtTelefPrimary.ReadOnly    = true;
                    txtTelefSecondary.ReadOnly  = true;
                    txtEmail.ReadOnly           = true;
                    txtLocation.ReadOnly        = true;
                    txtAdress.ReadOnly          = true;

                    this.dataGridView1.DataSource = this.personDatabaseConnection.GetAll();
                }
                else
                {
                    MessageBox.Show("Edad No Valida.");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            btnUpdate.Text = "Update";
            btnUpdate.Enabled           = true;

            txtNumSocio.ReadOnly        = true;
            txtSeniorityPartner.ReadOnly= true;
            txtTypePartner.ReadOnly     = true;
            txtShare.ReadOnly           = true;
            txtPost.ReadOnly            = true;
            txtFirstName.ReadOnly       = true;
            txtLastName.ReadOnly        = true;
            txtDni.ReadOnly             = true;
            txtAge.ReadOnly             = true;
            txtFamilyUnity.ReadOnly     = true;
            txtHeredaSitio.ReadOnly     = true;
            txtTelefPrimary.ReadOnly    = true;
            txtTelefSecondary.ReadOnly  = true;
            txtEmail.ReadOnly           = true;
            txtLocation.ReadOnly        = true;
            txtAdress.ReadOnly          = true;   

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
